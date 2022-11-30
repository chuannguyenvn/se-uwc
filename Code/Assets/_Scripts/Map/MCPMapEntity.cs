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
}