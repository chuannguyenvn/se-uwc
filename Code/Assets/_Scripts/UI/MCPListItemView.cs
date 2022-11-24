using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MCPListItemView : ListItemView<MCPData>
{
    public override void SetData(MCPData data)
    {
        PrimaryText = data.Address;
        SecondaryText = (data.Capacity * 100).ToString("F0") + "%";

        ChangeIconColor(data.Capacity);
        UpdateView();
    }

    private void ChangeIconColor(float capacity)
    {
        if (capacity < SystemConstants.MCP.AlmostFullThreshold)
        {
            image.color = VisualManager.Instance.MCPNotFullColor;
        }
        else if (capacity < SystemConstants.MCP.FullyLoadedThreshold)
        {
            image.color = VisualManager.Instance.MCPAlmostFullColor;
        }
        else
        {
            image.color = VisualManager.Instance.MCPFullyLoadedColor;
        }
    }
}