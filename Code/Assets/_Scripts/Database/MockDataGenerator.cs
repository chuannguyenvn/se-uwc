using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MockDataGenerator : PersistentSingleton<MockDataGenerator>
{
    private static readonly Vector2 STAFF_COORDINATE_MIN = new Vector2(10.754185f, 106.631181f);
    private static readonly Vector2 STAFF_COORDINATE_MAX = new Vector2(10.793629f, 106.693502f);

    private List<string> staffIds = new();

    private DateTime GetRandomDateTime()
    {
        return DateTime.Today.AddDays(-Random.Range(100, 1000));
    }

    private VehicleCategory GetRandomVehicleCategory()
    {
        var values = Enum.GetValues(typeof(VehicleCategory));
        var index = Random.Range(0, values.Length);
        return (VehicleCategory)values.GetValue(index);
    }

    private char GetRandomLetter()
    {
        return (char)Random.Range('A', 'Z' + 1);
    }

    private char GetRandomNumber()
    {
        return (char)Random.Range('0', '9' + 1);
    }

    private string GetRandomLicensePlate()
    {
        return "" + GetRandomLetter() + GetRandomLetter() + GetRandomLetter() + " - " +
               GetRandomNumber() + GetRandomNumber() + GetRandomNumber() + "." + GetRandomNumber() +
               GetRandomNumber();
    }

    private string GetRandomModel()
    {
        string model = "";
        for (int i = 0; i < 5; i++)
        {
            if (Random.Range(0, 2) == 1) model += GetRandomLetter();
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

    public StaffData GetMockStaffData()
    {
        staffIds.Add(Random.Range(0, 1000).ToString());
        return new StaffData(staffIds[^1], GetRandomName(), "[photo]", Gender.Male, GetRandomDateTime(),
            "[address]", Random.Range(1000000000, 999999999).ToString(), "Vietnam", GetRandomDateTime(),
            Random.Range(0, 2) == 0 ? Role.Collector : Role.Janitor, Random.Range(1000000, 10000000),
            Random.Range(STAFF_COORDINATE_MIN.x, STAFF_COORDINATE_MAX.x),
            Random.Range(STAFF_COORDINATE_MIN.y, STAFF_COORDINATE_MAX.y));
    }

    public MCPData GetMockMCPData()
    {
        return new MCPData("[address]", Random.Range(0f, 1f),
            Random.Range(STAFF_COORDINATE_MIN.x, STAFF_COORDINATE_MAX.x),
            Random.Range(STAFF_COORDINATE_MIN.y, STAFF_COORDINATE_MAX.y));
    }

    public VehicleData GetMockVehicleData()
    {
        return new VehicleData(GetRandomLicensePlate(), GetRandomVehicleCategory(), GetRandomModel(),
            Random.Range(1000f, 10000f), Random.Range(1000f, 10000f), Random.Range(1000f, 10000f));
    }

    public MessageData GetMockMessageData()
    {
        return new MessageData(AccountManager.Instance.AccountID, GetRandomStaffID(),
            GetRandomDateTime(), "[message content]");
    }
}