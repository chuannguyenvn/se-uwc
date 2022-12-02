using System.Collections.Generic;


public class DatabaseManager : PersistentSingleton<DatabaseManager>
{
    public List<StaffData> AllStaffs;
    public List<MCPData> AllMCPs;
    public List<VehicleData> AllVehicles;
    public Dictionary<string, Inbox> InboxByID;
    public List<TaskData> AllTasks;
    public List<MaintenanceLogData> AllMaintenanceLogs;

    protected override void Awake()
    {
        base.Awake();

        AllStaffs = DatabaseLoader.Instance.LoadAllStaffData();

        AllMCPs = DatabaseLoader.Instance.LoadAllMCPsData();

        AllVehicles = DatabaseLoader.Instance.LoadAllVehicleData();

        InboxByID = new();
        
        var allMessageData = DatabaseLoader.Instance.LoadAllMessageData();
        foreach (var messageData in allMessageData)
        {
            if (!InboxByID.ContainsKey(messageData.ReceiverID))
                InboxByID.Add(messageData.ReceiverID, new Inbox());
            
            InboxByID[messageData.ReceiverID].Messages.Add(messageData);
        }

        foreach (var (id, inbox) in InboxByID)
        {
            inbox.SortMessages();
        }

        AllTasks = DatabaseLoader.Instance.LoadAllTaskData();

        AllMaintenanceLogs = DatabaseLoader.Instance.LoadAllMaintenanceLogData();
    }
}