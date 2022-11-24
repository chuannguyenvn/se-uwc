using UnityEngine;


public class ResourceManager : PersistentSingleton<ResourceManager>
{
    [Header("World Annotations")] public RoutePolyline RoutePolyline;
    [Header("Item Views")] 
    public StaffListItemView StaffListItemView;
    public MCPListItemView MCPListItemView;
}