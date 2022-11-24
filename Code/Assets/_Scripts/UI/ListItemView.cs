using TMPro;
using UnityEngine;
using UnityEngine.UI;


public abstract class ListItemView<T> : MonoBehaviour where T : Data
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] protected Image image;
    [SerializeField] protected TMP_Text primaryText_TMP;
    [SerializeField] protected TMP_Text secondaryText_TMP;

    public float Height => rectTransform.sizeDelta.y;

    public string PrimaryText;
    public string SecondaryText;

    public abstract void SetData(T data);

    protected void UpdateView()
    {
        primaryText_TMP.text = PrimaryText;
        secondaryText_TMP.text = SecondaryText;
    }

    public void SetPosition(Vector2 pos)
    {
        rectTransform.anchoredPosition = pos;
    }
}