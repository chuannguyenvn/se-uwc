using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ListView<T> : MonoBehaviour where T : Data
{
    [SerializeField] protected ScrollRect scrollRect;
    
    protected Dictionary<T, ListItemView<T>> items = new();
    protected ListItemView<T> prefab;

    
    public abstract void Init();

    public virtual void AddItem(T data)
    {
        var itemView = Instantiate(prefab, scrollRect.content.transform)
            .GetComponent<ListItemView<T>>();

        itemView.SetPosition(new Vector2(0, -(items.Count * (prefab.Height + 10))));
        itemView.SetData(data);

        items.Add(data, itemView);
        UpdateScrollRect(prefab.Height);
    }

    protected void UpdateScrollRect(float itemViewHeight)
    {
        scrollRect.content.sizeDelta = new Vector2(0, items.Count * (itemViewHeight + 10));
    }
}
