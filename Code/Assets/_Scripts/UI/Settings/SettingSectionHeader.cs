using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingSectionHeader : MonoBehaviour
{
    [SerializeField] private TMP_Text header;
    [SerializeField] private RectTransform lineRectTransform;

    private const float LINE_MARGIN_LEFT = 10f;


    public void Init(string header, float totalWidth)
    {
        this.header.text = header;
        this.header.ForceMeshUpdate();
        var newWidth = totalWidth - this.header.textBounds.size.x - LINE_MARGIN_LEFT;
        lineRectTransform.sizeDelta = new Vector2(newWidth, lineRectTransform.sizeDelta.y);
    }
}