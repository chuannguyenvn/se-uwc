public class VehicleListItemView : ListItemView<VehicleData>
{
    public override void SetData(VehicleData data)
    {
        PrimaryText = data.LicensePlate;
        SecondaryText = data.Category.ToString();

        UpdateView();
    }
}