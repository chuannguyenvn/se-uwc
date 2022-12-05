using System;
using System.Collections.Generic;
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

    private Dictionary<InitState, int> workCountByInitState = new()
    {
        {InitState.MockDataGeneration, 0},
        {InitState.Data, 0},
        {InitState.Map, 0},
        {InitState.UI, 0},
    };

    // Event used for important classes to subscribe their initialize works to.
    public event Action<InitState> InitEventFlow;

    // Similar to InitEventFlow.
    public event Action<TerminateState> TerminateEventFlow;

    private void Start()
    {
        // foreach (var state in Enum.GetValues(typeof(InitState)))
        // {
        //     workCountByInitState.Add((InitState)state, 0);
        // }

        MapWrapper.Instance.abstractMap.OnInitialized += Init;
        
        Init();
    }

    private void Init()
    {
        InitEventFlow?.Invoke(InitState.MockDataGeneration);
        CompleteWork(InitState.MockDataGeneration);
    }

    private void Terminate()
    {
    }

    public void CompleteWork(InitState state)
    {
        Debug.Log("Com");
        workCountByInitState[state]--;
        if (workCountByInitState[state] > 0) return;

        switch (state)
        {
            case InitState.MockDataGeneration:
                InitEventFlow?.Invoke(InitState.Data);
                Debug.Log("Completed MockDataGeneration");
                break;
            case InitState.Data:
                InitEventFlow?.Invoke(InitState.Map);
                Debug.Log("Completed Data");
                break;
            case InitState.Map:
                InitEventFlow?.Invoke(InitState.UI);
                Debug.Log("Completed Map");
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

        workCountByInitState[state]++;
    }

    public void AddTerminateWork(Action terminateWork, TerminateState state)
    {
        TerminateEventFlow += (s) =>
        {
            if (s == state) terminateWork?.Invoke();
        };
    }
}