using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;

    [SerializeField] private Button loginButton;

    private void Start()
    {
        loginButton.onClick.AddListener(TryLogin);
    }

    private async void TryLogin()
    {
        if (CheckFormFulfillment() == false)
        {
            NotificationData fieldsNotFilled = new(NotificationType.Warning, GetFieldsNotFilledText());
            NotificationManager.Instance.EnqueueNotification(fieldsNotFilled);
            return;
        }

        BackendCommunicator.Instance.RequestLogin(usernameField.text, passwordField.text,
            (success, token) =>
            {
                if (success)
                {
                    AccountManager.Instance.SaveLoginCredentials(token);
                }
                else
                {
                    NotificationData loginFailed = new(NotificationType.Warning, GetLoginFailedText());
                    NotificationManager.Instance.EnqueueNotification(loginFailed);
                }
            });
    }

    private bool CheckFormFulfillment()
    {
        return usernameField.text != String.Empty && passwordField.text != String.Empty;
    }

    private string GetFieldsNotFilledText()
    {
        return LanguageTranslation.GetText(LanguageTranslation.TextType.Login_Unfilled_Fields,
            LanguageTranslation.ReturnTextOption.Sentence_case) + ".";
    }

    private string GetLoginFailedText()
    {
        return LanguageTranslation.GetText(LanguageTranslation.TextType.Login_Failed,
            LanguageTranslation.ReturnTextOption.Sentence_case) + ".";
    }
}