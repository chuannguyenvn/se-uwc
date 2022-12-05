using System;
using System.Collections;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;

public class CollectorMapEntity : SingleCoordinateMapEntity<StaffData>
{
    private CollectorCurrentPositionData currentPositionData;

    public void Init(StaffData data)
    {
        AssignData(data);

        button.onClick.AddListener(() => MapManager.Instance.CollectorInformationPopup.Show(data,
            new Vector2d(currentPositionData.Coordinate.Latitude,
                currentPositionData.Coordinate.Longitude)));

        StartCoroutine(UpdatePosition_CO());
    }

    public override void ValueChangedHandler()
    {
    }

    IEnumerator UpdatePosition_CO()
    {
        while (true)
        {
            BackendCommunicator.Instance.MapAPICommunicator.GetCollectorPosition(data.ID,
                (isSucceed, coordinate) =>
                {
                    if (isSucceed)
                        UpdateCoordinate(new Vector2d(coordinate.Latitude, coordinate.Longitude));
                });

            yield return new WaitForSeconds(5f);
        }
    }
}