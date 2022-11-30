using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;

public abstract class SingleCoordinateMapEntity<T> : MapEntity where T : Data
{
    protected T data;

    [SerializeField] protected Button button;
    protected Vector2d coordinate;

    public virtual void AssignData(T data)
    {
        this.data = data;
    }

    public abstract void UpdateCoordinate(Vector2d coordinate);

    public abstract void ValueChangedHandler();
}