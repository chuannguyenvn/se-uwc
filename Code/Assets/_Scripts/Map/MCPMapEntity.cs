using System;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;


public class MCPMapEntity : SingleCoordinateMapEntity<MCPData>
{
    [SerializeField] private Image background;

    public void Init(MCPData data)
    {
        AssignData(data);
        UpdateCoordinate(new Vector2d(data.Latitude, data.Longitude));
        MapWrapper.Instance.MapUpdated += MapUpdatedHandler;
    }
    
    public override void AssignData(MCPData data)
    {
        base.AssignData(data);
        data.ValueChanged += ValueChangedHandler;
        
        ValueChangedHandler();
    }

    private void OnDestroy()
    {
        data.ValueChanged -= ValueChangedHandler;
    }

    public override void UpdateCoordinate(Vector2d coordinate)
    {
        this.coordinate = coordinate;
        MapUpdatedHandler();
    }

    public override void ValueChangedHandler()
    {
        var capacity = data.Capacity;

        if (capacity < SystemConstants.MCP.AlmostFullThreshold)
            background.color = VisualManager.Instance.MCPNotFullColor;
        else if (capacity < SystemConstants.MCP.FullyLoadedThreshold)
            background.color = VisualManager.Instance.MCPAlmostFullColor;
        else
            background.color = VisualManager.Instance.MCPFullyLoadedColor;
    }

    protected override void MapUpdatedHandler()
    {
        transform.position = MapManager.Instance.GeoToWorldPosition(coordinate);
    }
}