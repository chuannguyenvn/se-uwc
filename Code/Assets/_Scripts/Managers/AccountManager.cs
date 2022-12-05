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
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6ImR1Yy5waEdsb2JhbCIsInJvbGUiOiJCYWNrT2ZmaWNlciIsImlhdCI6MTY3MDI1MjcyMCwiZXhwIjoxNjcwMjU0NTIwfQ.PupDfQGn1tXD7Hk9eZLHmemOzA_L7eALKTU8oHMrDcE";
        return loginToken.AccessToken;
    }
}