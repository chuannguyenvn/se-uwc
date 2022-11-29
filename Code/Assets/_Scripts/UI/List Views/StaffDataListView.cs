public class StaffDataListView : DataListView<StaffData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.StaffDataListItemView;

        var allStaff = DatabaseLoader.Instance.LoadAllStaffData();
        foreach (var staffData in allStaff)
        {
            AddDataItem(staffData);
        }
    }
}