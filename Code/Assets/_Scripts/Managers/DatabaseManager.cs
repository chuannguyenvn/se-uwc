using System;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseManager : PersistentSingleton<DatabaseManager>
{
    public List<StaffData> AllStaffs;
    public List<MCPData> AllMCPs;
    public List<VehicleData> AllVehicles;
    public Dictionary<string, Inbox> InboxesByID;
    public List<TaskData> AllTasks;
    public List<MaintenanceLogData> AllMaintenanceLogs;

    protected override void Awake()
    {
        base.Awake();
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.Data);
    }

    private void Init()
    {
        AllStaffs = DatabaseLoader.Instance.LoadAllStaffData();

        //AllMCPs = DatabaseLoader.Instance.LoadAllMCPsData();
        BackendCommunicator.Instance.MCP.GetAllMCP(((b, list) =>
        {
            Debug.Log("a");
            if (b == false) throw new Exception("fadfasaf");
                AllMCPs = list;
                ApplicationManager.Instance.CompleteWork(ApplicationManager.InitState.Data);
        }));
        AllVehicles = DatabaseLoader.Instance.LoadAllVehicleData();

        InboxesByID = new();

        var allMessageData = DatabaseLoader.Instance.LoadAllMessageData();
        foreach (var messageData in allMessageData)
        {
            AddMessageToInbox(messageData);
        }

        foreach (var (id, inbox) in InboxesByID)
        {
            inbox.SortMessages();
        }

        AllTasks = DatabaseLoader.Instance.LoadAllTaskData();

        AllMaintenanceLogs = DatabaseLoader.Instance.LoadAllMaintenanceLogData();
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
        return AllTasks.FindAll(task =>
            task.EmployeeID == staffData.ID && task.Timestamp.Date == dateTime.Date);
    }
}