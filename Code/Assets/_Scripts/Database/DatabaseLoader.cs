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
        return new List<VehicleData>()
        {
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
            MockDataGenerator.Instance.GetMockVehicleData(),
        };
    }

    public List<MessageData> LoadAllMessageData()
    {
        List<MessageData> messageDataList = new();

        for (int i = 0; i < 100; i++)
        {
            messageDataList.Add(MockDataGenerator.Instance.GetMockMessageData());
        }

        return messageDataList;
    }

    public List<TaskData> LoadAllTaskData()
    {
        List<TaskData> taskDataList = new();

        for (int i = 0; i < 100; i++)
        {
            taskDataList.Add(MockDataGenerator.Instance.GetMockTaskData());
        }

        return taskDataList;    }

    public List<MaintenanceLogData> LoadAllMaintenanceLogData()
    {
        return new List<MaintenanceLogData>() { };
    }
}