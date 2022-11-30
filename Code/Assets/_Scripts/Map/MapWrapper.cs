using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using MapboxDirectionRequestResult;

public class MapWrapper : Singleton<MapWrapper>
{
    public event Action MapUpdated;

    [SerializeField] private AbstractMap abstractMap;

    private Vector2 prevMousePos;
    private Vector2d start;
    private bool firstPointChosen = false;

    private void Start()
    {
        abstractMap.OnUpdated += OnMapUpdated;
    }

    private void OnDestroy()
    {
        abstractMap.OnUpdated -= OnMapUpdated;
    }

    private void OnMouseDown()
    {
        prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        var currentMousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDelta = prevMousePos - currentMousePos;

        if (mouseDelta == prevMousePos)
        {
            prevMousePos = currentMousePos;
            return;
        }

        abstractMap.UpdateMap(abstractMap.WorldToGeoPosition(mouseDelta));
        prevMousePos = currentMousePos;
    }

    private void Update()
    {
        var newZoomValue = Mathf.Clamp(abstractMap.Zoom + Input.mouseScrollDelta.y / 5, 10, 20);
        abstractMap.UpdateMap(newZoomValue);

        if (Input.GetMouseButtonDown(1))
        {
            if (firstPointChosen)
            {
                firstPointChosen = false;

                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var end = abstractMap.WorldToGeoPosition(mousePos);

                string uri = BuildRequestURI(start, end);
                var request = UnityWebRequest.Get(uri);
                StartCoroutine(ReadRequestResult(request));
            }
            else
            {
                firstPointChosen = true;
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                start = abstractMap.WorldToGeoPosition(mousePos);
            }
        }
    }

    private string BuildRequestURI(Vector2d start, Vector2d end)
    {
        string head = "https://api.mapbox.com/directions/v5/mapbox/driving/";
        string tail =
            "?geometries=geojson&access_token=pk.eyJ1IjoiY2h1YW5wcm8wMzAiLCJhIjoiY2xhcG51ZWg5MDFqbTNwb2FlaW52MXNvciJ9.kFN5GOg3C8cGlk2PN4Tleg";

        return head + start + ";" + end + tail;
    }

    private IEnumerator ReadRequestResult(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        var result = JsonConvert.DeserializeObject<Result>(request.downloadHandler.text);
        var rawCoordinates = result.routes[0].geometry.coordinates;

        List<Vector2d> coordinateList = new();
        foreach (var coordinate in rawCoordinates)
        {
            coordinateList.Add(new Vector2d(coordinate[1], coordinate[0]));
        }

        Instantiate(ResourceManager.Instance.RoutePolyline)
            .GetComponent<RoutePolyline>()
            .Init(coordinateList);
    }

    public void OnMapUpdated()
    {
        MapUpdated?.Invoke();
    }

    public Vector2 GeoToWorldPoint(Vector2d coordinate)
    {
        return abstractMap.GeoToWorldPosition(coordinate);
    }
}