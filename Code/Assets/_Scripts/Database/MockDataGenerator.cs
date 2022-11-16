using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MockDataGenerator : PersistentSingleton<MockDataGenerator>
{
    public DateTime GetRandomDateTime()
    {
        return DateTime.Today.AddDays(-Random.Range(100, 1000));
    }

    public StaffData GetMockStaffData()
    {
        return new StaffData(Random.Range(0, 1000).ToString(), "McPlaceholder", "photo", Gender.Male,
            GetRandomDateTime(), "address", Random.Range(1000000000, 999999999).ToString(), "Vietnam",
            GetRandomDateTime(), Random.Range(0, 2) == 0 ? Role.Collector : Role.Janitor,
            Random.Range(1000000, 10000000));
    }
}