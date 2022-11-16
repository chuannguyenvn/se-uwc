using System.Collections.Generic;
using UnityEngine;


public class DatabaseLoader : PersistentSingleton<DatabaseLoader>
{
    public List<StaffData> LoadAllStaffData()
    {
        return new List<StaffData>()
        {
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
        };
    }

    public List<MCPData> LoadAllMCPData()
    {
        return new List<MCPData>() { };
    }

    public List<VehicleData> LoadAllVehicleData()
    {
        return new List<VehicleData>() { };
    }

    public List<MessageData> LoadAllMessageData()
    {
        return new List<MessageData>() { };
    }

    public List<TaskData> LoadAllTaskData()
    {
        return new List<TaskData>() { };
    }

    public List<MaintenanceLogData> LoadAllMaintenanceLogData()
    {
        return new List<MaintenanceLogData>() { };
    }
}