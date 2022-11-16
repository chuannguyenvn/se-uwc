using System;

public class MessageData
{
    public string ID { get; set; }

    public string SenderID { get; set; }
    public string ReceiverID { get; set; }

    public DateTime Timestamp { get; set; }
    public string Content { get; set; }
}