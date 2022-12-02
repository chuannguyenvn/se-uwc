using System;
using System.Collections.Generic;


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

        AllStaffs = DatabaseLoader.Instance.LoadAllStaffData();

        AllMCPs = DatabaseLoader.Instance.LoadAllMCPsData();

        AllVehicles = DatabaseLoader.Instance.LoadAllVehicleData();

        InboxesByID = new();

        var allMessageData = DatabaseLoader.Instance.LoadAllMessageData();
        foreach (var messageData in allMessageData)
        {
            if (!InboxesByID.ContainsKey(messageData.ReceiverID))
                InboxesByID.Add(messageData.ReceiverID,
                    new Inbox(messageData.ReceiverID, GetStaffNameByID(messageData.ReceiverID)));

            InboxesByID[messageData.ReceiverID].Messages.Add(messageData);
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
}