using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


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
    [FormerlySerializedAs("SettingListItemView")]
    public GameObject BlankSettingListItemView;
    public Button Button;
    
    // @formatter:on
}