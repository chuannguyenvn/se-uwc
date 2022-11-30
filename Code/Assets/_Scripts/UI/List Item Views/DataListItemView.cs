using TMPro;
using UnityEngine;
using UnityEngine.UI;


public abstract class DataListItemView<T> : ListItemView where T : Data
{
    [SerializeField] protected Image image;
    [SerializeField] protected TMP_Text primaryText_TMP;
    [SerializeField] protected TMP_Text secondaryText_TMP;
    [SerializeField] protected Button button;

    public string PrimaryText;
    public string SecondaryText;

    public abstract void SetData(T data);

    protected void UpdateView()
    {
        primaryText_TMP.text = PrimaryText;
        secondaryText_TMP.text = SecondaryText;
    }
}