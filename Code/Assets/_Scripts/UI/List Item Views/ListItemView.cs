using System;
using UnityEngine;

public class ListItemView : MonoBehaviour
{
    protected RectTransform rectTransform;
    public float Height => rectTransform.sizeDelta.y;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetPosition(Vector2 pos)
    {
        rectTransform.anchoredPosition = pos;
    }

    public void SetParent(RectTransform rectTransform)
    {
        this.rectTransform.SetParent(rectTransform, false);
    }
}