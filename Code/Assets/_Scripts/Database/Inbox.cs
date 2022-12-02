using System.Collections.Generic;

public class Inbox : Data
{
    public string RecipientID;

    public string RecipientName;

    public List<MessageData> Messages;

    public void SortMessages()
    {
        Messages.Sort((messageA, messageB) => messageA.Timestamp > messageB.Timestamp ? 1 : -1);
    }
}