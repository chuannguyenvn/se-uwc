using UnityEngine;

public class MCPDataListView : DataListView<MCPData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.MCPDataListItemView;

        var allMCPs = DatabaseManager.Instance.AllMCPs;
        foreach (var mcpData in allMCPs)
        {
            AddDataItem(mcpData);
        }
    }
}