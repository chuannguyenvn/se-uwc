using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public abstract class ListView : MonoBehaviour, IShowHideAnimatable
{
    [SerializeField] protected ScrollRect scrollRect;
    protected List<ListItemView> itemViews = new();

    protected static float VERTICAL_SPACING = 10f;

    protected float initialX;

    protected virtual void Awake()
    {
        initialX = transform.position.x;
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.UI);
    }

    protected virtual void Init()
    {
    }

    public virtual void AddItem(ListItemView itemView)
    {
        var totalHeight = itemViews.Sum(i => i.Height);
        float yPos = 0;
        if (itemViews.Count != 0) yPos = -(totalHeight + itemViews.Count * VERTICAL_SPACING);
        itemView.SetParent(scrollRect.content);
        itemView.SetPosition(new Vector2(0, yPos));
        
        itemViews.Add(itemView);
        
        UpdateScrollRect();
    }

    protected virtual void UpdateScrollRect()
    {
        var totalHeight = itemViews.Sum(i => i.Height);
        var newScrollRectSize = new Vector2(0, totalHeight + (itemViews.Count - 1) * VERTICAL_SPACING);
        scrollRect.content.sizeDelta = newScrollRectSize;
    }

    protected void RemoveAllItemViews()
    {
        foreach (var itemView in itemViews)
        {
            Destroy(itemView.gameObject);
        }

        itemViews = new();
    }

    public virtual Task AnimateShow()
    {
        return gameObject.transform.DOMoveX(initialX, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.OutCubic)
            .AsyncWaitForCompletion();
    }

    public virtual Task AnimateHide()
    {
        return gameObject.transform.DOMoveX(initialX - 30f, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.InCubic)
            .AsyncWaitForCompletion();
    }
}