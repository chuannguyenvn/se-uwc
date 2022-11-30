using System;
using System.Threading.Tasks;
using Mapbox.Utils;
using UnityEngine;


public class MapManager : PersistentSingleton<MapManager>
{
    [SerializeField] private Transform mapTransform;
    [SerializeField] private MapWrapper mapWrapper;

    private void Start()
    {
        foreach (var mcpData in DatabaseManager.Instance.AllMCPs)
        {
            var mcp = Instantiate(ResourceManager.Instance.MCPMapEntity, mapTransform)
                .GetComponent<MCPMapEntity>();

            mcp.transform.SetParent(mapTransform);
            mcp.Init(mcpData);
        }
    }

    public Vector2d WorldToGeoPosition(Vector2 coordinate)
    {
        return mapWrapper.WorldToGeoPosition(coordinate);
    }

    public Vector2 GeoToWorldPosition(Vector2d coordinate)
    {
        return mapWrapper.GeoToWorldPosition(coordinate);
    }
}