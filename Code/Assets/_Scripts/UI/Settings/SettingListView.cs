using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingListView : MonoBehaviour
{
    [SerializeField] protected ScrollRect scrollRect;
    private RectTransform rectTransform;
    
    private const float HORIZONTAL_MARGIN = 10f;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        var headerPrefab = ResourceManager.Instance.SettingSectionHeader;

        var interfaceHeader = Instantiate(headerPrefab).GetComponent<SettingSectionHeader>();
        interfaceHeader.transform.SetParent(scrollRect.content.transform, false);
        interfaceHeader.Init("Interface Setting", rectTransform.rect.width - HORIZONTAL_MARGIN * 2);

        interfaceHeader.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
    }
}