using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectorInformationPopup : MapEntity
{
    // Debug //
    public int TaskLeftCount = 4;
    // Debug //

    private const float VERTICAL_POPUP_OFFSET = 0.3f;

    [SerializeField] private Image profilePicture;
    [SerializeField] private TMP_Text staffName;
    [SerializeField] private TMP_Text drivingVehicle;

    [SerializeField] private Button assignTaskButton;
    [SerializeField] private Button sendMessageButton;
    [SerializeField] private Button detailedInformationButton;

    [SerializeField] private TMP_Text prevDestination;
    [SerializeField] private TMP_Text currentDestination;
    [SerializeField] private TMP_Text nextDestination;
    [SerializeField] private TMP_Text evenMoreNextDestination;

    private RectTransform rectTransform;
    private Vector2d coordinate;

    private void Awake()
    {
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.UI);
    }

    private void Init()
    {
        rectTransform = GetComponent<RectTransform>();
        AdjustBox(TaskLeftCount);
    }

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

    private void AdjustBox(int taskCount)
    {
        if (taskCount == 4)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 450);
            prevDestination.gameObject.SetActive(true);
            currentDestination.gameObject.SetActive(true);
            nextDestination.gameObject.SetActive(true);
            evenMoreNextDestination.gameObject.SetActive(true);
        }

        if (taskCount == 3)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 390);
            prevDestination.gameObject.SetActive(true);
            currentDestination.gameObject.SetActive(true);
            nextDestination.gameObject.SetActive(true);
            evenMoreNextDestination.gameObject.SetActive(false);
        }

        if (taskCount == 2)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 330);
            prevDestination.gameObject.SetActive(true);
            currentDestination.gameObject.SetActive(true);
            nextDestination.gameObject.SetActive(false);
            evenMoreNextDestination.gameObject.SetActive(false);
        }

        if (taskCount == 1)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 270);
            prevDestination.gameObject.SetActive(true);
            currentDestination.gameObject.SetActive(false);
            nextDestination.gameObject.SetActive(false);
            evenMoreNextDestination.gameObject.SetActive(false);
        }

        if (taskCount == 0)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 210);
            prevDestination.gameObject.SetActive(false);
            currentDestination.gameObject.SetActive(false);
            nextDestination.gameObject.SetActive(false);
            evenMoreNextDestination.gameObject.SetActive(false);
        }
    }
}