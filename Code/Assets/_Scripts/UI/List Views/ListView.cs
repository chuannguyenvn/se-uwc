using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ListView : MonoBehaviour
{
    [SerializeField] protected ScrollRect scrollRect;
    protected List<ListItemView> itemViews = new();

    private const float VERTICAL_SPACING = 10f;

    public virtual void AddItem(ListItemView itemView)
    {
        var totalHeight = itemViews.Sum(i => i.Height);
        float yPos = 0;
        if (itemViews.Count != 0) yPos = -(totalHeight + itemViews.Count * VERTICAL_SPACING);
        itemView.SetPosition(new Vector2(0, yPos));
        
        itemViews.Add(itemView);
        
        UpdateScrollRect();
    }

    protected void UpdateScrollRect()
    {
        var totalHeight = itemViews.Sum(i => i.Height);
        var newScrollRectSize = new Vector2(0, totalHeight + (itemViews.Count - 1) * VERTICAL_SPACING);
        scrollRect.content.sizeDelta = newScrollRectSize;
    }
}