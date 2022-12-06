using System;
using UnityEngine;

public class AccountManager : PersistentSingleton<AccountManager>
{
    public string AccountID { get; private set; }

    private LoginToken loginToken;

    [SerializeField] private string token;

    public void SaveLoginCredentials(LoginToken loginToken)
    {
        this.loginToken = loginToken;
        token = loginToken.AccessToken;
    }

    public string GetAccessToken()
    {
        if (token != String.Empty) return token;
        return loginToken.AccessToken;
    }
}