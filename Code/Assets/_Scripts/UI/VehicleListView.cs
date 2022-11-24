public class VehicleListView : ListView<VehicleData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.VehicleListItemView;

        var allVehicles = DatabaseLoader.Instance.LoadAllVehicleData();
        foreach (var vehicleData in allVehicles)
        {
            AddItem(vehicleData);
        }
    }
}