using System;
using System.Collections;
using Mapbox.Json;
using UnityEngine;
using UnityEngine.Networking;

public class MessageDatabaseCommunicator : MonoBehaviour
{
    private const string ADD_MESSAGE_PATH = "/api/message/add";
    private const string GET_MESSAGE_PATH = "/api/message";

    public void AddMessage(MessageData messageData, Action<bool> callback)
    {
        StartCoroutine(AddMessage_CO(messageData, callback));
    }

    private IEnumerator AddMessage_CO(MessageData messageData, Action<bool> callback)
    {
        string messageDataJson = JsonConvert.SerializeObject(messageData);

        var request = BackendCommunicator.CreatePostRequest(ADD_MESSAGE_PATH, messageDataJson);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            callback?.Invoke(false);
            yield break;
        }

        callback?.Invoke(true);
    }

    public void GetMessage(string accountId, Action<bool, CollectorRouteTraversedData> callback)
    {
        StartCoroutine(GetMessage_CO(accountId, callback));
    }

    private IEnumerator GetMessage_CO(string accountId,
        Action<bool, CollectorRouteTraversedData> callback)
    {
        var request = BackendCommunicator.CreateGetRequest(string.Format(GET_MESSAGE_PATH, accountId));
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);
        if (request.result is not UnityWebRequest.Result.Success or UnityWebRequest.Result.ProtocolError)
        {
            callback?.Invoke(false, null);
            yield break;
        }

        var routeTraversedData =
            JsonConvert.DeserializeObject<CollectorRouteTraversedData>(request.downloadHandler.text);
        callback?.Invoke(true, routeTraversedData);
    }
}