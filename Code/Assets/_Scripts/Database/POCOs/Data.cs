using System;

public abstract class Data
{
    public string ID { get; set; }

    protected Data(string id)
    {
        ID = id;
    }

    public event Action ValueChanged;

    protected void OnValueChanged()
    {
        ValueChanged?.Invoke();
    }
}