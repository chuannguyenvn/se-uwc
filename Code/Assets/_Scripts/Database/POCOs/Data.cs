using System;

public abstract class Data
{
    public string ID { get; set; }

    public event Action ValueChanged;

    protected void OnValueChanged()
    {
        ValueChanged?.Invoke();
    }
}