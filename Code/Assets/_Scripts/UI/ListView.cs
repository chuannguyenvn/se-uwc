using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ListView<T> : MonoBehaviour where T : Data
{
    [SerializeField] protected ScrollRect scrollRect;
    
    protected Dictionary<T, ListItemView<T>> items = new();
    
    public abstract void Init();
    
    public abstract void AddItem(T data);

    protected void UpdateScrollRect(float itemViewHeight)
    {
        scrollRect.content.sizeDelta = new Vector2(0, items.Count * (itemViewHeight + 10));
    }
}
