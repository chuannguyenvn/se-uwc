using System.Collections.Generic;
using Mapbox.Utils;
using Shapes;
using UnityEngine;

public class RoutePolyline : MultipleCoordinatesMapEntity
{
    [SerializeField] private Polyline polyline;
    
    public override void Init(List<Vector2d> coordinates)
    {
        this.coordinates = coordinates;
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