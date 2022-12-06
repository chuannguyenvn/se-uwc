﻿using Newtonsoft.Json;

public class MCPData : Data
{
    [JsonProperty("id")] public string ID { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("address")] public string Address { get; set; }
    [JsonProperty("capacity")] public int Capacity { get; set; }
    [JsonProperty("latitude")] public double Latitude { get; set; }
    [JsonProperty("longitude")] public double Longitude { get; set; }

    private float statusPercentage;

    public float StatusPercentage
    {
        get => statusPercentage;
        set
        {
            statusPercentage = value;
            OnValueChanged();
        }
    }

    public MCPData(string id, string address, int capacity, double latitude, double longitude)
    {
        Address = address;
        Capacity = capacity;
        Latitude = latitude;
        Longitude = longitude;
    }
}