using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class MapAPICommunicator : MonoBehaviour
{
    private const string SET_COLLECTOR_WAYPOINTS_PATH = "/api/map/waypoints";
    private const string GET_COLLECTOR_POSITION_PATH = "/api/map/currentPosition/{0}";
    private const string GET_ALL_COLLECTOR_POSITION_PATH = "/api/map/allCurrentPosition";

    public void SetCollectorWaypoints(CollectorRouteData routeData, Action<bool> callback)
    {
        StartCoroutine(SetCollectorWaypoints_CO(routeData, callback));
    }

    private IEnumerator SetCollectorWaypoints_CO(CollectorRouteData routeData, Action<bool> callback)
    {
        string routeDataJson = JsonConvert.SerializeObject(routeData);

        var request = BackendCommunicator.CreatePostRequest(SET_COLLECTOR_WAYPOINTS_PATH, routeDataJson);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            callback?.Invoke(false);
            yield break;
        }

        callback?.Invoke(true);
    }

    public void GetCollectorPosition(string collectorId, Action<bool, Coordinate> callback)
    {
        StartCoroutine(GetCollectorPosition_CO(collectorId, callback));
    }

    private IEnumerator GetCollectorPosition_CO(string collectorId, Action<bool, Coordinate> callback)
    {
        var request =
            BackendCommunicator.CreateGetRequest(string.Format(GET_COLLECTOR_POSITION_PATH,
                collectorId));
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);
        if (request.result is not UnityWebRequest.Result.Success or UnityWebRequest.Result.ProtocolError)
        {
            callback?.Invoke(false, null);
            yield break;
        }

        var coordinate = JsonConvert.DeserializeObject<Coordinate>(request.downloadHandler.text);
        callback?.Invoke(true, coordinate);
    }

    public void GetAllCollectorPosition(Action<bool, List<CollectorCurrentPositionData>> callback)
    {
        StartCoroutine(GetAllCollectorPosition_CO(callback));
    }

    private IEnumerator GetAllCollectorPosition_CO(
        Action<bool, List<CollectorCurrentPositionData>> callback)
    {
        var request = BackendCommunicator.CreateGetRequest(GET_ALL_COLLECTOR_POSITION_PATH);
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);
        if (request.result is not UnityWebRequest.Result.Success or UnityWebRequest.Result.ProtocolError)
        {
            callback?.Invoke(false, null);
            yield break;
        }

        var collectorPosition =
            JsonConvert.DeserializeObject<List<CollectorCurrentPositionData>>(request.downloadHandler
                .text);
        callback?.Invoke(true, collectorPosition);
    }
}