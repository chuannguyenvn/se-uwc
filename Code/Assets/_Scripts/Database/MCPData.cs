public class MCPData : Data
{
    public string Address { get; set; }

    public float Capacity { get; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }
    
    public MCPData(string address, float capacity, float longitude, float latitude)
    {
        Address = address;
        Capacity = capacity;
        Longitude = longitude;
        Latitude = latitude;
    }
}