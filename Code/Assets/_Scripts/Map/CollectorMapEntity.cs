using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;

public class CollectorMapEntity : SingleCoordinateMapEntity<StaffData>
{
    public void Init(StaffData data)
    {
        // AssignData(data);
        // UpdateCoordinate(new Vector2d(data.Latitude, data.Longitude));
        //
        // button.onClick.AddListener(() =>
        //     MapManager.Instance.CollectorInformationPopup.Show(data,
        //         new Vector2d(data.Latitude, data.Longitude)));
    }

    public override void ValueChangedHandler()
    {

    }
}