using System.Collections.Generic;
using Mapbox.Utils;
using Shapes;
using UnityEngine;

public class RoutePolyline : MultipleCoordinatesMapEntity
{
    [SerializeField] private Polyline polyline;
    
    public void Init(List<List<double>> coordinates)
    {
        foreach (var coordinate in coordinates)
        {
            this.coordinates.Add(new Vector2d(coordinate[1], coordinate[0]));
        }

        MapWrapper.Instance.MapUpdated += MapUpdatedHandler;
    }

    protected override void MapUpdatedHandler()
    {
        List<Vector2> newPoints = new List<Vector2>();
        foreach (var coordinate in coordinates)
        {
            newPoints.Add(MapWrapper.Instance.GeoToWorldPoint(coordinate));
        }

        polyline.SetPoints(newPoints);
    }
}