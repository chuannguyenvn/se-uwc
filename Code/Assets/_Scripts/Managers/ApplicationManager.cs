using System;
using UnityEngine;

public class ApplicationManager : PersistentSingleton<ApplicationManager>
{
    // Initialize states. The program will start with the works tagged with the first state, then gradually move to the next state.
    public enum InitState
    {
        MockDataGeneration,
        Data,
        Map,
        UI,
    }

    // Similar to InitState, this enum is used to tag terminate/cleanup work.
    public enum TerminateState
    {
        Map,
        UI,
    }

    // Event used for important classes to subscribe their initialize works to.
    public event Action<InitState> InitEventFlow;
    
    // Similar to InitEventFlow.
    public event Action<TerminateState> TerminateEventFlow;

    private void Start()
    {
        MapWrapper.Instance.abstractMap.OnInitialized += Init;
    }

    private void Init()
    {
        InitEventFlow?.Invoke(InitState.MockDataGeneration);
    }

    private void Terminate()
    {
    }

    public void CompleteWork(InitState state)
    {
        switch (state)
        {
            case InitState.MockDataGeneration:
                InitEventFlow?.Invoke(InitState.Data);
                break;
            case InitState.Data:
                InitEventFlow?.Invoke(InitState.Map);
                break;
            case InitState.Map:
                InitEventFlow?.Invoke(InitState.UI);
                break;
            case InitState.UI:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
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