using Mapbox.Utils;
using UnityEngine;

public abstract class SingleCoordinateMapEntity : MapEntity
{
    protected Vector2d coordinate;

    public abstract void Init(Vector2d coordinate);
}