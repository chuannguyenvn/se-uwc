using System;
using UnityEngine;


public abstract class MapEntity : MonoBehaviour
{
    private void Awake()
    {
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.Map);
        ApplicationManager.Instance.AddTerminateWork(Terminate, ApplicationManager.TerminateState.Map);
    }

    protected virtual void Init()
    {
        MapWrapper.Instance.MapUpdated += MapUpdatedHandler;
    }

    protected virtual void Terminate()
    {
        MapWrapper.Instance.MapUpdated -= MapUpdatedHandler;
    }

    protected abstract void MapUpdatedHandler();
}