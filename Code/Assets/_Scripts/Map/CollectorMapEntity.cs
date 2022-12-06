using System;
using System.Collections;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;

public class CollectorMapEntity : SingleCoordinateMapEntity<StaffData>
{
    private CollectorCurrentPositionData currentPositionData;

    private Vector3 lastTransformPos;
    private Vector2d lastCoordinate;

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
                    {
                        var currentCoordinate = new Vector2d(coordinate.Latitude, coordinate.Longitude);
                        UpdateCoordinate(currentCoordinate);

                        transform.rotation = Quaternion.Euler(0, 0,(float)
                            Vector2d.Angle(Vector2d.up, currentCoordinate - lastCoordinate));
                        lastCoordinate = currentCoordinate;
                    }
                });

            yield return new WaitForSeconds(5f);
        }
    }
}