﻿public class StaffDataListView : DataListView<StaffData>
{
    protected override void Init()
    {
        base.Init();

        prefab = ResourceManager.Instance.StaffDataListItemView;

        var allStaffs = DatabaseManager.Instance.AllStaffs;
        foreach (var staffData in allStaffs)
        {
            AddDataItem(staffData);
        }
    }
}