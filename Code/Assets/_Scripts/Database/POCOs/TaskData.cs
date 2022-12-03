using System;

public class TaskData : Data
{
    public string EmployeeID { get; set; }
    public string MCPID { get; set; }

    public DateTime Timestamp { get; set; }
    public bool CheckedIn { get; set; }
    public bool CheckedOut { get; set; }

    public TaskData(string id, string employeeID, string mcpid, DateTime timestamp, bool checkedIn,
        bool checkedOut) : base(id)
    {
        EmployeeID = employeeID;
        MCPID = mcpid;
        Timestamp = timestamp;
        CheckedIn = checkedIn;
        CheckedOut = checkedOut;
    }
}