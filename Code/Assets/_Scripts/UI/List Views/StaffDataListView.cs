public class StaffDataListView : DataListView<StaffData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.StaffDataListItemView;

        var allStaffs = DatabaseManager.Instance.AllStaffs;
        foreach (var staffData in allStaffs)
        {
            AddDataItem(staffData);
        }
    }
}