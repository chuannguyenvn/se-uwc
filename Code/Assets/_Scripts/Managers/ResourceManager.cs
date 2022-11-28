using UnityEngine;
using UnityEngine.Serialization;


public class ResourceManager : PersistentSingleton<ResourceManager>
{
    // @formatter:off
    
    [Header("World Annotations")]
    public RoutePolyline RoutePolyline;
    
    [Header("Item Views")] 
    [FormerlySerializedAs("StaffListItemView")]
    public StaffDataListItemView staffDataListItemView;
    
    public MCPDataListItemView mcpDataListItemView;
    
    [FormerlySerializedAs("VehicleListItemView")]
    public VehicleDataListItemView vehicleDataListItemView;
    
    public SettingSectionHeader SettingSectionHeader;
    
    // @formatter:on
}