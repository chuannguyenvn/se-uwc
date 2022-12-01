using UnityEngine;


public class VisualManager : PersistentSingleton<VisualManager>
{
    [Header("Common")]
    public float InactiveViewButtonAlpha;

    [Header("MCPs")] 
    public Color MCPNotFullColor;
    public Color MCPAlmostFullColor;
    public Color MCPFullyLoadedColor;

    public Color GetMCPColor(float capacity)
    {
        if (capacity < SystemConstants.MCP.AlmostFullThreshold) return MCPNotFullColor;
        if (capacity < SystemConstants.MCP.FullyLoadedThreshold) return MCPAlmostFullColor;
        return MCPFullyLoadedColor;
    }
    
    public string GetMCPStatusText(float capacity)
    {
        if (capacity < SystemConstants.MCP.AlmostFullThreshold) return "Not full";
        if (capacity < SystemConstants.MCP.FullyLoadedThreshold) return "Almost full";
        return "Fully loaded";
    }
}