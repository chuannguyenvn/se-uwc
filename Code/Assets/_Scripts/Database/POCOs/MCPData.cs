public class MCPData : Data
{
    public string Address { get; private set; }


    private float capacity;

    public float Capacity
    {
        get => capacity;
        set
        {
            capacity = value;
            OnValueChanged();
        }
    }

    public float Latitude { get; private set; }
    public float Longitude { get; private set; }

    public MCPData(string id, string address, float capacity, float latitude, float longitude) : base(id)
    {
        Address = address;
        Capacity = capacity;
        Latitude = latitude;
        Longitude = longitude;
    }
}