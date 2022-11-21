using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapWrapper : MonoBehaviour
{
    [SerializeField] private AbstractMap abstractMap;

    private Vector2 prevMousePos;

    private void OnMouseDown()
    {
        prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        var currentMousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDelta = prevMousePos - currentMousePos;
        var oldCoordinateString = abstractMap.Options.locationOptions.latitudeLongitude;
        var splits = oldCoordinateString.Split(", ");
        var oldCoordinate = new Vector2(float.Parse(splits[1]), float.Parse(splits[0]));

        var newCoordinate = oldCoordinate + mouseDelta / abstractMap.Zoom;
        var newCoordinateString = newCoordinate.y + ", " + newCoordinate.x;

        abstractMap.Options.locationOptions.latitudeLongitude = newCoordinateString;
        abstractMap.UpdateMap();

        prevMousePos = currentMousePos;
    }

    private void Update()
    {
        var newZoomValue = Mathf.Clamp(abstractMap.Zoom + Input.mouseScrollDelta.y / 5, 10, 20);
        abstractMap.UpdateMap(newZoomValue);
    }
}