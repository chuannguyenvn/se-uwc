using UnityEngine;

public class ViewGroup : MonoBehaviour
{
    [SerializeField] private ViewType viewType;

    private void Awake()
    {
        ApplicationManager.Instance.AddInitWork(
            () => PrimarySidebar.Instance.ViewChanged += ViewChangedHandler,
            ApplicationManager.InitState.Map);
    }

    private void OnDestroy()
    {
        PrimarySidebar.Instance.ViewChanged -= ViewChangedHandler;
    }

    private void ViewChangedHandler(ViewType viewType)
    {
        if (this.viewType == viewType)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}