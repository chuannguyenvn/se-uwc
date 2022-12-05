using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class MockDataGenerator : PersistentSingleton<MockDataGenerator>
{
    private static readonly Vector2 STAFF_COORDINATE_MIN = new Vector2(10.754185f, 106.631181f);
    private static readonly Vector2 STAFF_COORDINATE_MAX = new Vector2(10.793629f, 106.693502f);

    private List<string> staffIds = new();
    private List<string> mcpIds = new();
    private List<string> vehicleIds = new();
    private List<string> messageIds = new();
    private List<string> taskIds = new();

    private DateTime GetRandomDateTime()
    {
        return DateTime.Today.AddDays(-Random.Range(100, 1000)).AddSeconds(Random.Range(0, 100000));
    }

    private VehicleCategory GetRandomVehicleCategory()
    {
        var values = Enum.GetValues(typeof(VehicleCategory));
        var index = Random.Range(0, values.Length);
        return (VehicleCategory)values.GetValue(index);
    }

    private char GetRandomLetter(bool isUpper)
    {
        if (!isUpper) return (char)Random.Range('a', 'z' + 1);
        return (char)Random.Range('A', 'Z' + 1);
    }

    private char GetRandomNumber()
    {
        return (char)Random.Range('0', '9' + 1);
    }

    private string GetRandomLicensePlate()
    {
        return "" + GetRandomLetter(true) + GetRandomLetter(true) + GetRandomLetter(true) + " - " +
               GetRandomNumber() + GetRandomNumber() + GetRandomNumber() + "." + GetRandomNumber() +
               GetRandomNumber();
    }

    private string GetRandomModel()
    {
        string model = "";
        for (int i = 0; i < 5; i++)
        {
            if (Random.Range(0, 2) == 1) model += GetRandomLetter(true);
            else model += GetRandomNumber();
        }

        return model;
    }

    private string GetRandomName()
    {
        switch (Random.Range(0, 4))
        {
            case 0: return "Steve McPlaceholder";
            case 1: return "Robert Sampletext Jr.";
            case 2: return "Lorem Ipsum";
            case 3: return "Nick Name";
            default: throw new Exception();
        }
    }

    private string GetRandomStaffID()
    {
        return staffIds[Random.Range(0, staffIds.Count)];
    }

    private string GetRandomMCPID()
    {
        return mcpIds[Random.Range(0, mcpIds.Count)];
    }

    private string GetRandomMessage()
    {
        string message = "";
        var randomLength = Random.Range(1, 200);

        for (int i = 0; i < randomLength; i++)
        {
            if (Random.Range(0, 4) == 0)
            {
                if (Random.Range(0, 10) == 0) message += ".";
                else message += " ";
            }
            else
            {
                if (message.Length == 0)
                    message += GetRandomLetter(true);
                else if (message[^1] == '.')
                    message += " " + GetRandomLetter(true);
                else
                    message += GetRandomLetter(false);
            }
        }

        return message[0] + message[1..].ToLower() + ".";
    }

    public string GetRandomAddress()
    {
        string address = "";
        var randomLength = Random.Range(10, 20);

        for (int i = 0; i < randomLength; i++)
        {
            address += GetRandomLetter(false);
        }

        return GetRandomLetter(true) + address;
    }

    public StaffData GetMockStaffData()
    {
        staffIds.Add(Random.Range(0, 1000).ToString());
        return new StaffData(staffIds[^1], GetRandomName(), "[photo]", Gender.Male, GetRandomDateTime(),
            "[address]", Random.Range(1000000000, 999999999).ToString(), "Vietnam", GetRandomDateTime(),
            Random.Range(0, 2) == 0 ? Role.Collector : Role.Janitor, Random.Range(1000000, 10000000),
            Random.Range(STAFF_COORDINATE_MIN.x, STAFF_COORDINATE_MAX.x),
            Random.Range(STAFF_COORDINATE_MIN.y, STAFF_COORDINATE_MAX.y));
    }

    // public MCPData GetMockMCPData()
    // {
    //     mcpIds.Add(Random.Range(0, 1000).ToString());
    //     return new MCPData(mcpIds[^1], GetRandomAddress(), Random.Range(0f, 1f),
    //         Random.Range(STAFF_COORDINATE_MIN.x, STAFF_COORDINATE_MAX.x),
    //         Random.Range(STAFF_COORDINATE_MIN.y, STAFF_COORDINATE_MAX.y));
    // }

    public VehicleData GetMockVehicleData()
    {
        vehicleIds.Add(Random.Range(0, 1000).ToString());
        return new VehicleData(vehicleIds[^1], GetRandomLicensePlate(), GetRandomVehicleCategory(),
            GetRandomModel(), Random.Range(1000f, 10000f), Random.Range(1000f, 10000f),
            Random.Range(1000f, 10000f));
    }

    public MessageData GetMockMessageData()
    {
        messageIds.Add(Random.Range(0, 1000).ToString());
        if (Random.Range(0, 2) == 0)
            return new MessageData(messageIds[^1], AccountManager.Instance.AccountID, GetRandomStaffID(),
                GetRandomDateTime(), GetRandomMessage());
        else
            return new MessageData(messageIds[^1], GetRandomStaffID(), AccountManager.Instance.AccountID,
                GetRandomDateTime(), GetRandomMessage());
    }

    // public TaskData GetMockTaskData()
    // {
    //     taskIds.Add(Random.Range(0, 1000).ToString());
    //     return new TaskData(taskIds[^1], GetRandomStaffID(), GetRandomMCPID(), DateTime.Today, false,
    //         false);
    // }
}