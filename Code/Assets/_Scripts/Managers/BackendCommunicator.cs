using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class BackendCommunicator : PersistentSingleton<BackendCommunicator>
{
    private const string MAIN_PATH = "https://se-uwc-be.vercel.app";

    private const string CREATE_ACCOUNT_PATH = "/api/auth/createAccount";
    private const string LOGIN_PATH = "/api/auth/login";
    private const string LOGOUT_PATH = "/api/auth/logout";

    private const string GET_EMPLOYEE_INFO_PATH = "/api/employee/info/{0}";

    private const string ASSIGN_WAYPOINTS_TO_COLLECTOR_PATH = "/api/map/waypoints";
    private const string GET_MCP_INFO_PATH = "/api/mcp/{0}";

    private const string GET_VEHICLE_INFO_PATH = "/api/vehicle/info/{0}";

    private void Start()
    {
        StartCoroutine(GetVehicleInfo_CO("23D-696.21"));
    }


    public void RequestLogin(string username, string password, Action<bool, LoginToken> callback)
    {
        StartCoroutine(Login_CO(username, password, callback));
    }

    private IEnumerator Login_CO(string username, string password, Action<bool, LoginToken> callback)
    {
        var user = new UserData();
        user.username = username;
        user.password = password;

        string json = JsonUtility.ToJson(user);

        var request = CreatePostRequest(LOGIN_PATH, json);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            callback?.Invoke(false, null);
            yield break;
        }

        var loginToken = JsonUtility.FromJson<LoginToken>(request.downloadHandler.text);
        callback?.Invoke(true, loginToken);
    }

    private IEnumerator GetVehicleInfo_CO(string vehicleId)
    {
        var request = CreateGetRequest(MAIN_PATH + string.Format(GET_VEHICLE_INFO_PATH, vehicleId));
        yield return request.SendWebRequest();

        Debug.Log(string.Format(GET_VEHICLE_INFO_PATH, vehicleId));

        Debug.Log(request.error);

        Debug.Log(request.downloadHandler.text);
    }

    private UnityWebRequest CreateGetRequest(string apiPath)
    {
        var request = new UnityWebRequest(MAIN_PATH + apiPath, "GET");
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }

    private UnityWebRequest CreatePostRequest(string apiPath, string json)
    {
        var request = new UnityWebRequest(MAIN_PATH + apiPath, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }
}

public class UserData
{
    public string username;
    public string password;
}