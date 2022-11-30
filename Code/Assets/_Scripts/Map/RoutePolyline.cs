using System.Collections.Generic;
using Mapbox.Utils;
using Shapes;
using UnityEngine;

public class RoutePolyline : MultipleCoordinatesMapEntity
{
    [SerializeField] private Polyline polyline;
    
    public override void UpdateCoordinates(List<Vector2d> coordinates)
    {
        this.coordinates = coordinates;
        MapWrapper.Instance.MapUpdated += MapUpdatedHandler;
    }

    protected override void MapUpdatedHandler()
    {
        List<Vector2> newPoints = new List<Vector2>();
        foreach (var coordinate in coordinates)
        {
            newPoints.Add(MapManager.Instance.GeoToWorldPosition(coordinate));
        }

        polyline.SetPoints(newPoints);
    }
}