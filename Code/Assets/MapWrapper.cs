using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapWrapper : MonoBehaviour
{
    [SerializeField] private AbstractMap abstractMap;

    private Vector2 initMousePos;

    public void OnDrag(PointerEventData eventData)
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("Dragggggg");
        initMousePos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        
    }

    private void OnMouseDrag()
    {
        var mouseDelta = initMousePos - (Vector2)Input.mousePosition;
        var oldCoordinateString = abstractMap.Options.locationOptions.latitudeLongitude;
        var splits = oldCoordinateString.Split(", ");
        var oldCoordinate = new Vector2(float.Parse(splits[1]), float.Parse(splits[0]));

        var newCoordinate = oldCoordinate + mouseDelta;
        var newCoordinateString = newCoordinate.y + ", " + newCoordinate.x;

        abstractMap.Options.locationOptions.latitudeLongitude = newCoordinateString;
        abstractMap.UpdateMap();
    }
}