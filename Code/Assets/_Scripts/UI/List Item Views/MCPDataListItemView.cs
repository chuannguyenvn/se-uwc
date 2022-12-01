public class MCPDataListItemView : DataListItemView<MCPData>
{
    public override void SetData(MCPData data)
    {
        PrimaryText = data.Address;
        SecondaryText = (data.Capacity * 100).ToString("F0") + "%";

        ChangeIconColor(data.Capacity);
        UpdateView();

        button.onClick.AddListener(() => MCPInformationPanel.Instance.Show(data));
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