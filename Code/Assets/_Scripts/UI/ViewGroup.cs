using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ViewGroup : MonoBehaviour, IShowHideAnimatable
{
    [SerializeField] private ViewType viewType;

    [SerializeField] private GameObject listView;
    [SerializeField] private GameObject informationPanel;

    private List<IShowHideAnimatable> animatables = new();

    private void Awake()
    {
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.UI);
        ApplicationManager.Instance.AddTerminateWork(Terminate, ApplicationManager.TerminateState.UI);
    }

    private void Init()
    {
        PrimarySidebar.Instance.ViewChanged += ViewChangedHandler;

        if (listView != null)
        {
            animatables.Add(listView.GetComponent<IShowHideAnimatable>());
        }

        if (informationPanel != null)
        {
            animatables.Add(informationPanel.GetComponent<IShowHideAnimatable>());
        }

        AnimateHide();
    }

    private void Terminate()
    {
        PrimarySidebar.Instance.ViewChanged -= ViewChangedHandler;
    }

    private void ViewChangedHandler(ViewType changeTo)
    {
        if (viewType == changeTo)
        {
            PrimarySidebar.Instance.ShowAnimation = AnimateShow();
        }
        else if (viewType == PrimarySidebar.Instance.CurrentViewType)
        {
            PrimarySidebar.Instance.HideAnimation = AnimateHide();
        }
    }

    public Task AnimateShow()
    {
        List<Task> showTasks = new();

        foreach (var animatable in animatables)
        {
            showTasks.Add(animatable.AnimateShow());
        }

        return Task.WhenAll(showTasks);
    }

    public Task AnimateHide()
    {
        List<Task> hideTasks = new();

        foreach (var animatable in animatables)
        {
            hideTasks.Add(animatable.AnimateHide());
        }

        return Task.WhenAll(hideTasks);
    }
}