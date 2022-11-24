public class VehicleData : Data
{
    public string LicensePlate { get; set; }
    public VehicleCategory Category { get; set; }
    public string Model { get; set; }
    public float Weight { get; set; }
    public float Capacity { get; set; }
    public float FuelConsumption { get; set; }

    public VehicleData(string licensePlate, VehicleCategory category, string model, float weight,
        float capacity, float fuelConsumption)
    {
        LicensePlate = licensePlate;
        Category = category;
        Model = model;
        Weight = weight;
        Capacity = capacity;
        FuelConsumption = fuelConsumption;
    }
}