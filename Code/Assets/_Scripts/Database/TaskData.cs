using System;

public class TaskData
{
    public string ID { get; set; }

    public string EmployeeID { get; set; }
    public string MCPID { get; set; }
    
    public DateTime Timestamp { get; set; }
    public bool CheckedIn { get; set; }
    public bool CheckedOut { get; set; }
}