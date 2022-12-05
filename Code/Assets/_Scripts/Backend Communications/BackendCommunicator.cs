using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapbox.Utils;
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
    private const string GET_ALL_COLLECTOR_POSITION_PATH = "/api/map/allCurrentPosition";

    private const string GET_VEHICLE_INFO_PATH = "/api/vehicle/info/{0}";

    [SerializeField] private MCPCommunicator mcpCommunicator;
    public MCPCommunicator MCP => mcpCommunicator;
    
    private void Start()
    {
        void Callback(bool success, List<CollectorRouteData> list)
        {
            if (success)
                foreach (var collectorRoute in list)
                {
                    Debug.Log(collectorRoute.Route[0]);
                }
            else
            {
                Debug.Log("fuck");
            }
        }

        StartCoroutine(GetAllCollectorPosition(Callback));
        StartCoroutine(AssignWaypointsToCollector("20b30c5b3c",
            new List<Vector2d>() {new Vector2d(10.7d, 106.6),}));
    }


    public void RequestLogin(string username, string password, Action<bool, LoginToken> callback)
    {
        StartCoroutine(Login_CO(username, password, callback));
    }

    private IEnumerator Login_CO(string username, string password, Action<bool, LoginToken> callback)
    {
        var user = new UserData {username = username, password = password};

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
        var request = CreateGetRequest(string.Format(GET_VEHICLE_INFO_PATH, vehicleId));
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) Debug.LogWarning("Request failed.");
        Debug.Log(request.downloadHandler.text);
    }

    private IEnumerator AssignWaypointsToCollector(string staffId, List<Vector2d> waypoints)
    {
        List<Coordinate> points = new();
        foreach (var waypoint in waypoints)
        {
            points.Add(new Coordinate(waypoint.x, waypoint.y));
        }

        var task = new CollectorRouteData() {CollectorId = staffId, Route = points};
        var taskJson = JsonUtility.ToJson(task);

        var request = CreatePostRequest(ASSIGN_WAYPOINTS_TO_COLLECTOR_PATH, taskJson);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success) Debug.LogWarning("Request failed.");
    }

    private IEnumerator GetAllCollectorPosition(Action<bool, List<CollectorRouteData>> callback)
    {
        var request = CreateGetRequest(GET_ALL_COLLECTOR_POSITION_PATH);
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);
        if (request.result is not UnityWebRequest.Result.Success or UnityWebRequest.Result.ProtocolError)
        {
            callback?.Invoke(false, null);
            yield break;
        }

        var collectorsRouteData =
            JsonUtility.FromJson<List<CollectorRouteData>>(request.downloadHandler.text);
        
        callback?.Invoke(true, collectorsRouteData);
    }

    public static UnityWebRequest CreateGetRequest(string apiPath)
    {
        var request = new UnityWebRequest(MAIN_PATH + apiPath, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }

    public static UnityWebRequest CreatePostRequest(string apiPath, string json)
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