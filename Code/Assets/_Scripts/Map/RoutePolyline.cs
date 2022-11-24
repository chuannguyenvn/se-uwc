using System;
using System.Collections.Generic;
using Mapbox.Utils;
using Shapes;
using UnityEngine;

public class RoutePolyline : MonoBehaviour
{
    [SerializeField] private Polyline polyline;

    private List<Vector2d> coordinates = new();

    public void Init(List<List<double>> coordinates)
    {
        foreach (var coordinate in coordinates)
        {
            this.coordinates.Add(new Vector2d(coordinate[1], coordinate[0]));
        }

        MapWrapper.Instance.MapUpdated += MapUpdatedHandler;
    }

    private void OnDestroy()
    {
        MapWrapper.Instance.MapUpdated -= MapUpdatedHandler;
    }

    private void MapUpdatedHandler()
    {
        List<Vector2> newPoints = new List<Vector2>();
        foreach (var coordinate in coordinates)
        {
            newPoints.Add(MapWrapper.Instance.GeoToWorldPoint(coordinate));
        }
        polyline.SetPoints(newPoints);
    }
}