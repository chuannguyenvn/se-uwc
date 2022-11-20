using System;
using System.Collections.Generic;
using UnityEngine;

public class StaffListView : ListView<StaffData>
{
    private static float itemViewHeight;
    private static StaffListItemView prefab;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.StaffListItemView;
        itemViewHeight = prefab.Height;

        var allStaff = DatabaseLoader.Instance.LoadAllStaffData();
        foreach (var staffData in allStaff)
        {
            AddItem(staffData);
        }
    }

    public override void AddItem(StaffData data)
    {
        var itemView = Instantiate(prefab, scrollRect.content.transform)
            .GetComponent<StaffListItemView>();

        itemView.SetPosition(new Vector2(0, -(items.Count * (itemViewHeight + 10))));
        itemView.SetData(data);

        items.Add(data, itemView);
        UpdateScrollRect(prefab.Height);
    }
}