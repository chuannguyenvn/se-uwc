using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Mapbox.Utils;
using Shapes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MCPMapEntity : SingleCoordinateMapEntity<MCPData>
{
    #region Toggle

    public static event Action<MCPMapEntity, bool> ToggleStateChanged;

    private static bool groupingSelect;

    public static bool GroupingSelect
    {
        get => groupingSelect;
        set
        {
            groupingSelect = value;
            if (groupingSelect)
            {
                foreach (var (key, _) in ToggleStates)
                {
                    key.ChangeToSelectMode();
                }
            }
            else
            {
                foreach (var (key, _) in ToggleStates)
                {
                    key.ChangeToInfoMode();
                    key.HideDisc();
                }
            }
        }
    }

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
        
        ChangeToInfoMode();
        HideDisc();
    }

    public override void ValueChangedHandler()
    {
        var percentage = data.StatusPercentage;

        background.color = choiceDisc.Color = chosenOrderText.color =
            VisualManager.Instance.GetMCPColor(percentage / 100f);
    }

    private void ChangeToInfoMode()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            PrimarySidebar.Instance.OnViewChanged(ViewType.MCPsOverview);
            MCPInformationPanel.Instance.Show(data);
        });
    }

    private void ChangeToSelectMode()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            if (GroupingSelect)
            {
                ToggleStates[this] = !ToggleStates[this];

                if (ToggleStates[this])
                {
                    ShowDisc();
                    ChosenEntities.Add(this);
                }
                else
                {
                    HideDisc();
                    ChosenEntities.Remove(this);
                }

                ToggleStateChanged?.Invoke(this, ToggleStates[this]);
            }
            else
            {
                choiceDisc.gameObject.SetActive(ToggleStates[this]);
            }
        });
    }

    private void ShowDisc()
    {
        choiceDisc.gameObject.SetActive(true);
        choiceDisc.transform.DORotate(new Vector3(0, 0, -90), 45f, RotateMode.WorldAxisAdd)
            .SetSpeedBased(true)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }

    private void HideDisc()
    {
        choiceDisc.transform.DOKill();
        choiceDisc.gameObject.SetActive(false);
        chosenOrderText.text = "";
    }
}