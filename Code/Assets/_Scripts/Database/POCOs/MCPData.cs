using Newtonsoft.Json;

public class MCPData : Data
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("address")]
    public string Address { get;  set; }

    
    private int capacity;

    [JsonProperty("capacity")]
    public int Capacity { get; set; }
    // {
    //     get => capacity;
    //     set
    //     {
    //         capacity = value;
    //         OnValueChanged();
    //     }
    // }

    [JsonProperty("latitude")]
    public double Latitude { get;  set; }
    
    
    [JsonProperty("longitude")]
    public double Longitude { get;  set; }

    public MCPData(string id, string address, int capacity, double latitude, double longitude) : base(id)
    {
        Address = address;
        Capacity = capacity;
        Latitude = latitude;
        Longitude = longitude;
    }
}