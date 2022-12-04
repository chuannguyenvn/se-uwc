using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PrimarySidebar : Singleton<PrimarySidebar>
{
    public event Action<ViewType> ViewChanged;

    [Header("Buttons")] [SerializeField] private SidebarButton mapOverviewButton;
    [SerializeField] private SidebarButton staffOverviewButton;
    [SerializeField] private SidebarButton mcpsOverviewButton;
    [SerializeField] private SidebarButton vehiclesOverviewButton;
    [SerializeField] private SidebarButton messageOverviewButton;
    [SerializeField] private SidebarButton settingsButton;

    [Header("Views")] [SerializeField] private ViewGroup mapViewGroup;
    [SerializeField] private ViewGroup staffViewGroup;
    [SerializeField] private ViewGroup mcpsViewGroup;
    [SerializeField] private ViewGroup vehiclesViewGroup;
    [SerializeField] private ViewGroup messageViewGroup;
    [SerializeField] private ViewGroup settingsViewGroup;

    [HideInInspector] public ViewType CurrentViewType = ViewType.None;
    private GameObject currentViewObject;

    public Task ShowAnimation;
    public Task HideAnimation;

    private void Start()
    {
        StartCoroutine(NextFrameCall_CO());
    }

    public async void OnViewChanged(ViewType changeTo)
    {
        ViewChanged?.Invoke(changeTo);
        if (HideAnimation != null) await HideAnimation;
        if (ShowAnimation != null) await ShowAnimation;
        CurrentViewType = changeTo;
    }

    private IEnumerator NextFrameCall_CO()
    {
        yield return null;
        OnViewChanged(ViewType.MapOverview);
    }
}

public enum ViewType
{
    None,
    MapOverview,
    StaffsOverview,
    MCPsOverview,
    VehiclesOverview,
    MessagesOverview,
    SettingsOverview,
}