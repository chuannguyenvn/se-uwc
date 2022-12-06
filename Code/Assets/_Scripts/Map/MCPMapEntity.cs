using System;
using System.Collections.Generic;
using DG.Tweening;
using Mapbox.Utils;
using Shapes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MCPMapEntity : SingleCoordinateMapEntity<MCPData>
{
    #region Toggle

    public static event Action<MCPMapEntity, bool> ToggleStateChanged;

    public static bool GroupingSelect = false;
    public static Dictionary<MCPMapEntity, bool> ToggleStates = new();
    public static List<MCPMapEntity> ChosenEntities = new();

    public static void ResetToggleState()
    {
        foreach (var key in new List<MCPMapEntity>(ToggleStates.Keys))
        {
            ToggleStates[key] = false;
        }

        ChosenEntities = new();
    }

    #endregion

    [SerializeField] private Image background;
    [SerializeField] private Disc choiceDisc;
    [SerializeField] private TMP_Text chosenOrderText;

    public void Init(MCPData data)
    {
        ToggleStates.Add(this, false);

        AssignData(data);
        UpdateCoordinate(new Vector2d(data.Latitude, data.Longitude));

        ToggleStateChanged += (_, _) =>
        {
            var index = ChosenEntities.FindIndex(entity => entity == this);
            if (index == -1)
            {
                chosenOrderText.text = "";
            }
            else
            {
                chosenOrderText.text = (index + 1).ToString();
            }
        };

        button.onClick.AddListener(() =>
        {
            if (GroupingSelect)
            {
                ToggleStates[this] = !ToggleStates[this];

                if (ToggleStates[this])
                {
                    choiceDisc.gameObject.SetActive(true);
                    choiceDisc.transform.DORotate(new Vector3(0, 0, -90), 45f, RotateMode.WorldAxisAdd)
                        .SetSpeedBased(true)
                        .SetLoops(-1)
                        .SetEase(Ease.Linear);
                    ChosenEntities.Add(this);
                }
                else
                {
                    choiceDisc.transform.DOKill();
                    ChosenEntities.Remove(this);
                    choiceDisc.gameObject.SetActive(false);
                }

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
        var percentage = data.StatusPercentage;
        
        background.color = choiceDisc.Color = chosenOrderText.color =
            VisualManager.Instance.GetMCPColor(percentage / 100f);
    }
}