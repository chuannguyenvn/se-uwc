public class StaffDataListView : DataListView<StaffData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.staffDataListItemView;

        var allStaff = DatabaseLoader.Instance.LoadAllStaffData();
        foreach (var staffData in allStaff)
        {
            AddDataItem(staffData);
        }
    }
}