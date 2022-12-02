using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class InformationPanel<T> : Singleton<InformationPanel<T>> where T : Data
{
    [SerializeField] protected Button backButton;

    protected override void Awake()
    {
        base.Awake();
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.UI);
    }

    protected void Init()
    {
        PrimarySidebar.Instance.ViewChanged += ViewChangedHandler;
        Hide();
    }

    public virtual void Show(T data)
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ViewChangedHandler(ViewType viewType)
    {
        Hide();
    }

    private void OnDestroy()
    {
        if (PrimarySidebar.Instance != null) PrimarySidebar.Instance.ViewChanged -= ViewChangedHandler;
    }
}