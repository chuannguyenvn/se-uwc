using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;


public class Chatbox : MonoBehaviour, IShowHideAnimatable
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public virtual Task AnimateShow()
    {
        return rectTransform.DOAnchorPosX(0, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.OutCubic)
            .AsyncWaitForCompletion();
    }

    public virtual Task AnimateHide()
    {
        return rectTransform.DOAnchorPosX(2000, VisualManager.Instance.ListAndPanelTime)
            .SetEase(Ease.InCubic)
            .AsyncWaitForCompletion();
    }
}