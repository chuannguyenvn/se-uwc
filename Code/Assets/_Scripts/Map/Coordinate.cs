using UnityEngine;

public class Coordinate
{    public const string AnchorCoordinate = "10.7758439, 106.7017555";
    
    // public static string TranslateToMapboxCoordinate(Vector2 unityCoordinate)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public static Vector2 TranslateToUnityCoordinate(string mapboxCoordinate)
    // {
    //     throw new NotImplementedException();
    // }

    
    public Vector2 UnityCoordinate { get; }
    public string MapboxCoordinate { get; }
    

    // public Coordinate(Vector2 unityCoordinate)
    // {
    //     UnityCoordinate = unityCoordinate;
    //     MapboxCoordinate = TranslateToMapboxCoordinate(unityCoordinate);
    // }
    //
    // public Coordinate(string mapboxCoordinate)
    // {
    //     MapboxCoordinate = mapboxCoordinate;
    //     UnityCoordinate = TranslateToUnityCoordinate(mapboxCoordinate);
    // }
}