using System;
using Newtonsoft.Json;

public abstract class Data
{
    [JsonProperty("id")]
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