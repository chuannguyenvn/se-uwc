using UnityEngine;


public class VisualManager : PersistentSingleton<VisualManager>
{
    [Header("Common")]
    public float InactiveViewButtonAlpha;

    [Header("MCPs")] 
    public Color MCPNotFullColor;
    public Color MCPAlmostFullColor;
    public Color MCPFullyLoadedColor;
}