using System;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseManager : PersistentSingleton<DatabaseManager>
{
    private List<StaffData> allStaffs;
    private List<MCPData> allMCPs;
    private List<VehicleData> allVehicles;
    private List<MessageData> allMessages;
    private List<TaskData> allTasks;
    private List<MaintenanceLogData> allMaintenanceLogs;

    private void Start()
    {
        allStaffs = DatabaseLoader.Instance.LoadAllStaffData();
        allMCPs = DatabaseLoader.Instance.LoadAllMCPsData();
        allVehicles = DatabaseLoader.Instance.LoadAllVehicleData();
        allMessages = DatabaseLoader.Instance.LoadAllMessageData();
        allTasks = DatabaseLoader.Instance.LoadAllTaskData();
        allMaintenanceLogs = DatabaseLoader.Instance.LoadAllMaintenanceLogData();
    }
}