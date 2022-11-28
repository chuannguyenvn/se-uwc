﻿using UnityEngine;

public class MCPDataListView : DataListView<MCPData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.mcpDataListItemView;

        var allMCPs = DatabaseLoader.Instance.LoadAllMCPsData();
        foreach (var mcpData in allMCPs)
        {
            AddDataItem(mcpData);
        }
    }
}