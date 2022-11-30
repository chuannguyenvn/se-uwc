using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectorInformationPopup : MapEntity
{
    private const float VERTICAL_POPUP_OFFSET = 0.3f;

    [SerializeField] private Image profilePicture;
    [SerializeField] private TMP_Text staffName;
    [SerializeField] private TMP_Text drivingVehicle;

    [SerializeField] private Button assignTaskButton;
    [SerializeField] private Button sendMessageButton;
    [SerializeField] private Button detailedInformationButton;

    private Vector2d coordinate;

    public void Show(StaffData data, Vector2d position)
    {
        gameObject.SetActive(true);
        
        staffName.text = data.Name;
        drivingVehicle.text = "is driving " + "[vehicle type]" + " " + "[vehicle plate]";
        coordinate = position;
        
        transform.SetSiblingIndex(transform.parent.childCount - 1);

        MapUpdatedHandler();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    protected override void MapUpdatedHandler()
    {
        transform.position = MapManager.Instance.GeoToWorldPosition(coordinate) +
                             Vector2.up * VERTICAL_POPUP_OFFSET;
    }
}