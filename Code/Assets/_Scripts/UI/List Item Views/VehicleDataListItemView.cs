public class VehicleDataListItemView : DataListItemView<VehicleData>
{
    public override void SetData(VehicleData data)
    {
        PrimaryText = data.LicensePlate;
        SecondaryText = data.Category.ToString();

        UpdateView();
        
        button.onClick.AddListener(() => VehicleInformationPanel.Instance.Show(data));
    }
    
    protected override void UpdateView()
    {
        primaryText_TMP.text = PrimaryText;
        secondaryText_TMP.text = SecondaryText;
    }
}