using System.Collections.Generic;


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
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
            MockDataGenerator.Instance.GetMockStaffData(),
        };
    }

    public List<MCPData> LoadAllMCPsData()
    {
        return new List<MCPData>()
        {
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
            MockDataGenerator.Instance.GetMockMCPData(),
        };
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