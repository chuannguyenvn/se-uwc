using System;

public class MessageData : Data
{
    public string SenderID { get; set; }
    public string ReceiverID { get; set; }

    public DateTime Timestamp { get; set; }
    public string Content { get; set; }
}