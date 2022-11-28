public class VehicleDataListView : DataListView<VehicleData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.vehicleDataListItemView;

        var allVehicles = DatabaseLoader.Instance.LoadAllVehicleData();
        foreach (var vehicleData in allVehicles)
        {
            AddDataItem(vehicleData);
        }
    }
}