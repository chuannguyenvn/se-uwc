using System;
using UnityEngine;

public class AccountManager : PersistentSingleton<AccountManager>
{
    public string AccountID { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        ApplicationManager.Instance.AddInitWork(Init, ApplicationManager.InitState.Data);
    }
    
    // Debug //

    [SerializeField] private string debugAccountID;

    private void Init()
    {
        AccountID = debugAccountID;
    }

    // Debug //
}