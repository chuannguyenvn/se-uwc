using UnityEngine;


public class MCPListView : ListView<MCPData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.MCPListItemView;

        var allMCPs = DatabaseLoader.Instance.LoadAllMCPsData();
        foreach (var staffData in allMCPs)
        {
            AddItem(staffData);
        }
    }
}