using System.Collections.Generic;


public class DatabaseManager : PersistentSingleton<DatabaseManager>
{
    public List<StaffData> AllStaffs;
    public List<MCPData> AllMCPs;
    public List<VehicleData> AllVehicles;
    public List<MessageData> AllMessages;
    public List<TaskData> AllTasks;
    public List<MaintenanceLogData> AllMaintenanceLogs;

    protected override void Awake()
    {
        base.Awake();
        AllStaffs = DatabaseLoader.Instance.LoadAllStaffData();
        AllMCPs = DatabaseLoader.Instance.LoadAllMCPsData();
        AllVehicles = DatabaseLoader.Instance.LoadAllVehicleData();
        AllMessages = DatabaseLoader.Instance.LoadAllMessageData();
        AllTasks = DatabaseLoader.Instance.LoadAllTaskData();
        AllMaintenanceLogs = DatabaseLoader.Instance.LoadAllMaintenanceLogData();
    }
}