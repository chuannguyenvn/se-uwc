using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
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
    }
}