using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MockDataGenerator : PersistentSingleton<MockDataGenerator>
{
    private static readonly Vector2 STAFF_COORDINATE_MIN = new Vector2(10.754185f, 106.631181f);
    private static readonly Vector2 STAFF_COORDINATE_MAX = new Vector2(10.793629f, 106.693502f);

    public DateTime GetRandomDateTime()
    {
        return DateTime.Today.AddDays(-Random.Range(100, 1000));
    }

    public StaffData GetMockStaffData()
    {
        return new StaffData(Random.Range(0, 1000).ToString(), "McPlaceholder", "photo", Gender.Male,
            GetRandomDateTime(), "address", Random.Range(1000000000, 999999999).ToString(), "Vietnam",
            GetRandomDateTime(), Random.Range(0, 2) == 0 ? Role.Collector : Role.Janitor,
            Random.Range(1000000, 10000000),
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
        return new VehicleData("ABC-123", VehicleCategory.Frontloader, "sadf",
            Random.Range(1000f, 10000f), Random.Range(1000f, 10000f), Random.Range(1000f, 10000f));
    }
}