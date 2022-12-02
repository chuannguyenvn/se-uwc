public class StaffDataListItemView : DataListItemView<StaffData>
{
    public override void SetData(StaffData data)
    {
        PrimaryText = data.Name;
        SecondaryText = data.Role + " - currently at " + data.HomeAddress;

        UpdateView();
        
        button.onClick.AddListener(() => StaffInformationPanel.Instance.Show(data));
    }
}