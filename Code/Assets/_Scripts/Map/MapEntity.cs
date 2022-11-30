using System;
using UnityEngine;


public abstract class MapEntity : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        MapWrapper.Instance.MapUpdated -= MapUpdatedHandler;
    }

    protected virtual void OnDisable()
    {
        MapWrapper.Instance.MapUpdated -= MapUpdatedHandler;
    }

    protected abstract void MapUpdatedHandler();
}