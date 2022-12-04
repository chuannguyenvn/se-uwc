using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class InformationPanel<T> : Singleton<InformationPanel<T>>, IShowHideAnimatable
    where T : Data
{
    [SerializeField] protected Button backButton;
    private float initialX;

    protected override void Awake()
    {
        base.Awake();
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.UI);
    }

    protected void Init()
    {
        initialX = transform.position.x;
        transform.position += Vector3.right * 30f;
        PrimarySidebar.Instance.ViewChanged += ViewChangedHandler;
        Hide();
    }

    protected abstract void SetData(T data);

    public async void Show(T data)
    {
        gameObject.SetActive(true);

        await AnimateHide();
        SetData(data);
        await AnimateShow();
    }

    public async void Hide()
    {
        await AnimateHide();

        gameObject.SetActive(false);
    }

    public Task AnimateShow()
    {
        return gameObject.transform.DOMoveX(initialX, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.OutCubic)
            .AsyncWaitForCompletion();
    }

    public Task AnimateHide()
    {
        return gameObject.transform.DOMoveX(initialX + 30f, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.InCubic)
            .AsyncWaitForCompletion();
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