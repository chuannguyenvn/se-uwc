using System;
using UnityEngine;

public class AccountManager : PersistentSingleton<AccountManager>
{
    public string AccountID { get; private set; }

    private LoginToken loginToken;

    public void SaveLoginCredentials(LoginToken loginToken)
    {
        this.loginToken = loginToken;
    }
}