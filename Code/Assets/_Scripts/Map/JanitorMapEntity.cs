using Mapbox.Utils;
using UnityEngine;

public class JanitorMapEntity : SingleCoordinateMapEntity<StaffData>
{
    public void Init(StaffData data)
    {
        AssignData(data);
        UpdateCoordinate(new Vector2d(data.Latitude, data.Longitude));
    }

    public override void ValueChangedHandler()
    {
    }
}