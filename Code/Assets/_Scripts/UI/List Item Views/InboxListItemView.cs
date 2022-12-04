using UnityEngine;

public class InboxListItemView : DataListItemView<Inbox>
{
    public override void SetData(Inbox data)
    {
        PrimaryText = data.RecipientName;
        var latestMessage = data.Messages[^1];
        SecondaryText = latestMessage.Content;

        UpdateView();

        secondaryText_TMP.ForceMeshUpdate(true);

        var characterInfos = secondaryText_TMP.textInfo.characterInfo;
        var lastVisibleCharIndex = 0;
        for (int i = 0; i < characterInfos.Length; i++)
        {
            if (characterInfos[i].character != ' ' && !characterInfos[i].isVisible)
            {
                lastVisibleCharIndex = i - 3;
                break;
            }
        }

        if (lastVisibleCharIndex > 0)
        {
            SecondaryText = latestMessage.Content[..lastVisibleCharIndex] + "...";
            UpdateView();
        }

        button.onClick.AddListener(() => ListViewManager.Instance.InboxListView.OnInboxChosen(data));
    }

    protected override void UpdateView()
    {
        primaryText_TMP.text = PrimaryText;
        secondaryText_TMP.text = SecondaryText;
    }
}