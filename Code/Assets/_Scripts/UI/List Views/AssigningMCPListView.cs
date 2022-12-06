using System;
using System.Collections.Generic;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;


public class AssigningMCPListView : DataListView<MCPData>
{
    [SerializeField] private Button confirmButton;

    protected override void Init()
    {
        base.Init();
        prefab = ResourceManager.Instance.AssigningMcpListItemView;
        AnimateHide();

        confirmButton.onClick.AddListener(() =>
        {
            CollectorRouteData collectorRouteData = new();
            List<Vector2d> route = new List<Vector2d>();

            collectorRouteData.Route = new List<Coordinate>();
            foreach (var itemView in itemViews)
            {
                if (itemView is DataListItemView<MCPData> dataListItemView)
                {
                    route.Add(new Vector2d(dataListItemView.Data.Latitude,
                        dataListItemView.Data.Longitude));
                }
                else throw new Exception();
            }

            MapManager.Instance.GetRoute(route, (getRouteSucceeded, waypoints) =>
            {
                if (!getRouteSucceeded)
                {
                    return;
                }

                foreach (var waypoint in waypoints)
                {
                    collectorRouteData.Route.Add(new Coordinate(waypoint.x, waypoint.y));
                }
                
                collectorRouteData.CollectorId = StaffInformationPanel.Instance.Data.ID;
                BackendCommunicator.Instance.MapAPICommunicator.SetCollectorWaypoints(collectorRouteData,
                    isSucceeded =>
                    {
                        if (isSucceeded)
                        {
                            NotificationManager.Instance.EnqueueNotification(
                                new NotificationData(NotificationType.Info,
                                    LanguageTranslation.GetText(
                                        LanguageTranslation.TextType.MCP_Assign_Succeed,
                                        LanguageTranslation.ReturnTextOption.Sentence_case) + "."));
                        }
                        else
                        {
                            NotificationManager.Instance.EnqueueNotification(
                                new NotificationData(NotificationType.Warning,
                                    LanguageTranslation.GetText(
                                        LanguageTranslation.TextType.MCP_Assign_Fail,
                                        LanguageTranslation.ReturnTextOption.Sentence_case) + "."));
                        }

                        MCPMapEntity.ResetToggleState();
                        AnimateHide();
                    });
            });
        });
    }
}