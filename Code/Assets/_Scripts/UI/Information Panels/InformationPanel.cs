using UnityEngine;
using UnityEngine.UI;

public abstract class InformationPanel<T> : Singleton<InformationPanel<T>> where T : Data
{
    [SerializeField] protected Button backButton;

    public virtual void Show(T data)
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}