using System;
using UnityEngine;


public class MapManager : PersistentSingleton<MapManager>
{
    [SerializeField] private Transform MapTransform;

    private void Start()
    {
        foreach (var mcpData in DatabaseManager.Instance.AllMCPs)
        {
            var mcp = Instantiate(ResourceManager.Instance.MCPMapEntity, MapTransform)
                .GetComponent<MCPMapEntity>();
            
        }
    }
}