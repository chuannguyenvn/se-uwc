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

    public string GetAccessToken()
    {
        return
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImR1Yy5waEdsb2JhbCIsInJvbGUiOiJCYWNrIG9mZmljZXIiLCJpYXQiOjE2NzAyNDg4OTcsImV4cCI6MTY3MDI1MDY5N30.9rtKOXx22u5ZEH-1-_i3DtZ_H67ovQ-9FLErvX2f0ls";
        return loginToken.AccessToken;
    }
}