using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageDataListView : DataListView<MessageData>
{
    [SerializeField] private Image profilePicture;
    [SerializeField] private TMP_Text accountName;
    [SerializeField] private TMP_Text status;

    protected override void Init()
    {
        base.Init();

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

        // profilePicture.sprite = [something];
        accountName.text = inbox.RecipientName;
        // status.text = [something];
        scrollRect.content.anchoredPosition = new Vector2(0, scrollRect.content.sizeDelta.y - 600);
    }

    private void OnDestroy()
    {
        if (ListViewManager.Instance != null && ListViewManager.Instance.InboxListView != null)
            ListViewManager.Instance.InboxListView.InboxChosen -= InboxChosenHandler;
    }
    
    public override Task AnimateHide()
    {
        return rectTransform.DOAnchorPosX(2000, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.InCubic)
            .AsyncWaitForCompletion();
    }
}