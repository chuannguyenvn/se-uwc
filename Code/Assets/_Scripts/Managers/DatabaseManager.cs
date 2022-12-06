﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseManager : PersistentSingleton<DatabaseManager>
{
    public List<StaffData> AllStaffs
    {
        get
        {
            List<StaffData> list = new List<StaffData>();
            list.AddRange(AllJanitors);
            list.AddRange(AllCollectors);
            return list;
        }
    }

    public List<StaffData> AllJanitors;
    public List<StaffData> AllCollectors;
    public List<MCPData> AllMCPs;
    public List<VehicleData> AllVehicles;
    public Dictionary<string, Inbox> InboxesByID;
    public List<TaskData> AllTasks;
    public List<MaintenanceLogData> AllMaintenanceLogs;

    protected override void Awake()
    {
        base.Awake();
        ApplicationManager.Instance.AddInitWork(RetrieveAllCollectorData,
            ApplicationManager.InitState.Data);
        ApplicationManager.Instance.AddInitWork(RetrieveAllJanitorData,
            ApplicationManager.InitState.Data);
        ApplicationManager.Instance.AddInitWork(RetrieveAllMCPData, ApplicationManager.InitState.Data);
        ApplicationManager.Instance.AddInitWork(RetrieveAllVehicleData,
            ApplicationManager.InitState.Data);
    }

    private void Init()
    {
        // InboxesByID = new();
        //
        // var allMessageData = DatabaseLoader.Instance.LoadAllMessageData();
        // foreach (var messageData in allMessageData)
        // {
        //     AddMessageToInbox(messageData);
        // }
        //
        // foreach (var (id, inbox) in InboxesByID)
        // {
        //     inbox.SortMessages();
        // }
        //
        // AllTasks = DatabaseLoader.Instance.LoadAllTaskData();
        //
        // AllMaintenanceLogs = DatabaseLoader.Instance.LoadAllMaintenanceLogData();

        //ApplicationManager.Instance.CompleteWork(ApplicationManager.InitState.Data);
    }

    private IEnumerator PeriodicallyRetrieveMCPStatus_CO()
    {
        while (true)
        {
            foreach (var mcpData in AllMCPs)
            {
                BackendCommunicator.Instance.MCPAPICommunicator.GetMCPStatePercentage(mcpData.ID,
                    (isSucceeded, percentage) =>
                    {
                        if (isSucceeded)
                        {
                            Debug.Log("per: " + percentage);
                            mcpData.StatusPercentage = percentage;
                        }
                    });
            }
            
            yield return new WaitForSeconds(5);
        }
    }

    private void RetrieveAllCollectorData()
    {
        BackendCommunicator.Instance.StaffDatabaseCommunicator.GetAllCollector((success, list) =>
        {
            Debug.Log("called");

            if (success == false)
            {
                NotificationManager.Instance.EnqueueNotification(
                    new NotificationData(NotificationType.Error, "Cannot retrieve staff data."));
            }
            else
            {
                AllCollectors = list;
                ApplicationManager.Instance.CompleteWork(ApplicationManager.InitState.Data);
            }
        });
    }

    private void RetrieveAllJanitorData()
    {
        BackendCommunicator.Instance.StaffDatabaseCommunicator.GetAllJanitor((success, list) =>
        {
            Debug.Log("called");

            if (success == false)
            {
                NotificationManager.Instance.EnqueueNotification(
                    new NotificationData(NotificationType.Error, "Cannot retrieve staff data."));
            }
            else
            {
                AllJanitors = list;
                ApplicationManager.Instance.CompleteWork(ApplicationManager.InitState.Data);
            }
        });
    }

    private void RetrieveAllMCPData()
    {
        BackendCommunicator.Instance.MCPDatabaseCommunicator.GetAllMCP((success, list) =>
        {
            if (success)
            {
                AllMCPs = list;
                ApplicationManager.Instance.CompleteWork(ApplicationManager.InitState.Data);
                StartCoroutine(PeriodicallyRetrieveMCPStatus_CO());
            }
            else
            {
                NotificationManager.Instance.EnqueueNotification(
                    new NotificationData(NotificationType.Error, "Cannot retrieve MCP data."));
            }
        });
    }

    private void RetrieveAllVehicleData()
    {
        BackendCommunicator.Instance.VehicleDatabaseCommunicator.GetAllVehicle((success, list) =>
        {
            if (success == false)
            {
                NotificationManager.Instance.EnqueueNotification(
                    new NotificationData(NotificationType.Error, "Cannot retrieve vehicle data."));
            }

            else
            {
                AllVehicles = list;
                ApplicationManager.Instance.CompleteWork(ApplicationManager.InitState.Data);
            }
        });
    }
    
    public string GetStaffNameByID(string staffId)
    {
        foreach (var staffData in AllStaffs)
        {
            if (staffData.ID == staffId) return staffData.Name;
        }

        throw new Exception();
    }

    private void AddMessageToInbox(MessageData messageData)
    {
        string otherPersonId = messageData.ReceiverID == AccountManager.Instance.AccountID
            ? messageData.SenderID
            : messageData.ReceiverID;

        if (!InboxesByID.ContainsKey(otherPersonId))
            InboxesByID.Add(otherPersonId, new Inbox(otherPersonId, GetStaffNameByID(otherPersonId)));

        InboxesByID[otherPersonId].Messages.Add(messageData);
    }

    public MCPData GetMCPDataByID(string mcpId)
    {
        var index = AllMCPs.FindIndex(mcp => mcp.ID == mcpId);
        if (index == -1) throw new Exception("MCP ID not found.");
        return AllMCPs[index];
    }

    public List<TaskData> FilterStaffsTasksByDate(StaffData staffData, DateTime dateTime)
    {
        return new List<TaskData>();
        // return AllTasks.FindAll(task =>
        //     task.EmployeeID == staffData.ID && task.Timestamp.Date == dateTime.Date);
    }
}