using UnityEngine;


public class VisualManager : PersistentSingleton<VisualManager>
{
    // @formatter:off
    
    [Header("Common")]
    public float InactiveViewButtonAlpha;
    
    [Header("Theme")]
    public Color PrimaryColor;
    public Color SecondaryColor;
    public Color PrimaryTextColor;
    public Color SecondaryTextColor;
    public Color StaffEntityColor;

    [Header("MCPs")] 
    public Color MCPNotFullColor;
    public Color MCPAlmostFullColor;
    public Color MCPFullyLoadedColor;
    
    [Header("Animations")]
    public float ListAndPanelTime;

    // @formatter:on

    public Color GetMCPColor(float percentage)
    {
        if (percentage < SystemConstants.MCP.AlmostFullThreshold) return MCPNotFullColor;
        if (percentage < SystemConstants.MCP.FullyLoadedThreshold) return MCPAlmostFullColor;
        return MCPFullyLoadedColor;
    }

    public string GetMCPStatusText(float percentage)
    {
        if (percentage < SystemConstants.MCP.AlmostFullThreshold) return "Not full";
        if (percentage < SystemConstants.MCP.FullyLoadedThreshold) return "Almost full";
        return "Fully loaded";
    }
}