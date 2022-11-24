public class StaffListView : ListView<StaffData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.StaffListItemView;

        var allStaff = DatabaseLoader.Instance.LoadAllStaffData();
        foreach (var staffData in allStaff)
        {
            AddItem(staffData);
        }
    }
}