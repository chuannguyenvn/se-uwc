using Mapbox.Utils;
using UnityEngine;


public class MCPMapEntity : SingleCoordinateMapEntity
{
    public override void Init(Vector2d coordinate)
    {
        this.coordinate = coordinate;
    }

    protected override void MapUpdatedHandler()
    {
        transform.position = MapWrapper.Instance.GeoToWorldPoint(coordinate);
    }
}