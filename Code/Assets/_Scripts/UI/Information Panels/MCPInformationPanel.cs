using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MCPInformationPanel : InformationPanel<MCPData>
{
    [SerializeField] private TMP_Text address;
    [SerializeField] private Image capacityBar;
    [SerializeField] private Image capacityTextBackground;
    [SerializeField] private TMP_Text status;
    [SerializeField] private TMP_Text capacityPercentage;

    public override void Show(MCPData data)
    {
        gameObject.SetActive(true);

        address.text = data.Address;
        capacityBar.transform.localScale = new Vector3(data.Capacity, 1, 1);
        status.text = VisualManager.Instance.GetMCPStatusText(data.Capacity);
        capacityPercentage.text = Mathf.CeilToInt(data.Capacity * 100) + "%";

        var mcpColor = VisualManager.Instance.GetMCPColor(data.Capacity);
        capacityBar.color = capacityTextBackground.color = mcpColor;
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }
}