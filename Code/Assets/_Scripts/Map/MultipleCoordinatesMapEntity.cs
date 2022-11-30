using System.Collections.Generic;
using Mapbox.Utils;
using UnityEngine;


public abstract class MultipleCoordinatesMapEntity : MapEntity
{
    protected List<Vector2d> coordinates = new();
}