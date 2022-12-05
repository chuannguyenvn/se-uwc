using System;
using System.Collections.Generic;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;


public class MCPMapEntity : SingleCoordinateMapEntity<MCPData>
{
    #region Toggle

    public static event Action<MCPMapEntity, bool> ToggleStateChanged; 

    public static bool GroupingSelect = false;
    public static Dictionary<MCPMapEntity, bool> ToggleStates = new();

    public static void ResetToggleState()
    {
        foreach (var (key, _) in ToggleStates)
        {
            ToggleStates[key] = false;
        }
    }

    #endregion

    [SerializeField] private Image background;

    public void Init(MCPData data)
    {
        ToggleStates.Add(this, false);

        AssignData(data);
        UpdateCoordinate(new Vector2d(data.Latitude, data.Longitude));

        button.onClick.AddListener(() =>
        {
            if (GroupingSelect)
            {
                ToggleStates[this] = !ToggleStates[this];
                ToggleStateChanged?.Invoke(this, ToggleStates[this]);
            }
            else
            {
                var coordinate = new Vector2d(data.Latitude, data.Longitude);
                MapManager.Instance.MCPInformationPopup.Show(data, coordinate);
            }
        });
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