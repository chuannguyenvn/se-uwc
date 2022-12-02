using System;
using UnityEngine;

public class ApplicationManager : PersistentSingleton<ApplicationManager>
{
    public enum InitState
    {
        MockDataGeneration,
        Data,
        Map,
        UI,
    }
    
    public enum TerminateState
    {
        Map,
    }

    public event Action<InitState> InitEventFlow;
    public event Action<TerminateState> TerminateEventFlow;

    private void Start()
    {
        InitEventFlow?.Invoke(InitState.MockDataGeneration);
        InitEventFlow?.Invoke(InitState.Data);
        InitEventFlow?.Invoke(InitState.Map);
        InitEventFlow?.Invoke(InitState.UI);
    }

    private void Terminate()
    {
        
    }

    public void AddInitWork(Action initWork, InitState state)
    {
        InitEventFlow += (s) =>
        {
            if (s == state) initWork?.Invoke();
        };
    }
    
    public void AddTerminateWork(Action terminateWork, TerminateState state)
    {
        TerminateEventFlow += (s) =>
        {
            if (s == state) terminateWork?.Invoke();
        };
    }
}