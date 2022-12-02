using System;
using UnityEngine;

public class MessageDataListView : DataListView<MessageData>
{
    protected override void Init()
    {
        VERTICAL_SPACING = 20f;
        prefab = ResourceManager.Instance.MessageDataListItemView;

        ListViewManager.Instance.InboxListView.InboxChosen += InboxChosenHandler;
    }

    private void InboxChosenHandler(Inbox inbox)
    {
        RemoveAllItemViews();

        foreach (var messageData in inbox.Messages)
        {
            AddDataItem(messageData);
        }

        scrollRect.content.anchoredPosition = new Vector2(0, scrollRect.content.sizeDelta.y - 600);
    }

    private void OnDestroy()
    {
        if (ListViewManager.Instance != null && ListViewManager.Instance.InboxListView != null)
            ListViewManager.Instance.InboxListView.InboxChosen -= InboxChosenHandler;
    }
}