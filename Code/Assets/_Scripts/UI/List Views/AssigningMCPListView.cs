using System;
using System.Collections.Generic;
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
            collectorRouteData.Route = new List<Coordinate>();
            foreach (var itemView in itemViews)
            {
                if (itemView is DataListItemView<MCPData> dataListItemView)
                {
                    Coordinate coordinate = new Coordinate(dataListItemView.Data.Latitude,
                        dataListItemView.Data.Longitude);
                    collectorRouteData.Route.Add(coordinate);
                }
                else throw new Exception();
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
    }
}