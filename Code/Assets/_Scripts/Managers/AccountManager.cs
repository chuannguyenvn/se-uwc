using System;
using UnityEngine;

public class AccountManager : PersistentSingleton<AccountManager>
{
    public string AccountID { get; private set; }

    // Debug //

    [SerializeField] private string debugAccountID;

    private void Start()
    {
        AccountID = debugAccountID;
    }

    // Debug //
}