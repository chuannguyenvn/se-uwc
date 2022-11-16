using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimarySidebar : Singleton<PrimarySidebar>
{
    public event Action<ViewType> ViewChanged;

    [Header("Buttons")]
    [SerializeField] private SidebarButton mapOverviewButton;
    [SerializeField] private SidebarButton staffOverviewButton;
    [SerializeField] private SidebarButton mcpsOverviewButton;
    [SerializeField] private SidebarButton vehiclesOverviewButton;
    [SerializeField] private SidebarButton messageOverviewButton;
    [SerializeField] private SidebarButton settingsButton;

    [Header("Views")] 
    [SerializeField] private ViewGroup mapViewGroup;
    [SerializeField] private ViewGroup staffViewGroup;
    [SerializeField] private ViewGroup mcpsViewGroup;
    [SerializeField] private ViewGroup vehiclesViewGroup;
    [SerializeField] private ViewGroup messageViewGroup;
    [SerializeField] private ViewGroup settingsViewGroup;

    private ViewType currentViewType;
    private GameObject currentViewObject;

    private void Start()
    {
        OnViewChanged(ViewType.MapOverview);
    }

    public void OnViewChanged(ViewType viewType)
    {
        currentViewType = viewType;
        ViewChanged?.Invoke(viewType);
        Debug.Log("Switched to " + viewType);
    }
}

public enum ViewType
{
    MapOverview,
    StaffOverview,
    MCPsOverview,
    VehiclesOverview,
    MessageOverview,
    SettingsOverview,
}