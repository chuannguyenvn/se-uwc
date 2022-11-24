using UnityEngine;
using UnityEngine.UI;

public class SidebarButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image buttonIcon;
    [SerializeField] private ViewType viewType;
    public ViewType ViewType => viewType;

    private void Start()
    {
        button.onClick.AddListener(() => PrimarySidebar.Instance.OnViewChanged(viewType));
        PrimarySidebar.Instance.ViewChanged += ViewChangedHandler;
    }

    private void OnDestroy()
    {
        PrimarySidebar.Instance.ViewChanged -= ViewChangedHandler;
    }

    private void ViewChangedHandler(ViewType viewType)
    {
        if (this.viewType == viewType)
        {
            buttonIcon.color = buttonIcon.color.SetAlpha(1f);
        }
        else
        {
            buttonIcon.color = buttonIcon.color.SetAlpha(VisualManager.Instance.InactiveViewButtonAlpha);
        }
    }
}