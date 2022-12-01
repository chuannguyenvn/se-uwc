using UnityEngine;
using UnityEngine.UI;

public abstract class InformationPanel<T> : Singleton<InformationPanel<T>> where T : Data
{
    [SerializeField] protected Button backButton;

    public abstract void Show(T data);
    public abstract void Hide();
}