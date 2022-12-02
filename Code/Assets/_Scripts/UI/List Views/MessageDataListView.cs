using System;
using UnityEngine;

public class MessageDataListView : DataListView<MessageData>
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        prefab = ResourceManager.Instance.MessageDataListItemView;

        ListViewManager.Instance.InboxListView.InboxChosen += InboxChosenHandler;
    }

    private void InboxChosenHandler(Inbox inbox)
    {
        Debug.Log("yo");
        foreach (var messageData in inbox.Messages)
        {
            AddDataItem(messageData);
        }
    }

    private void OnDestroy()
    {
        if (ListViewManager.Instance != null && ListViewManager.Instance.InboxListView != null)
            ListViewManager.Instance.InboxListView.InboxChosen -= InboxChosenHandler;
    }
}