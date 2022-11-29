using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ResourceManager : PersistentSingleton<ResourceManager>
{
    // @formatter:off
    
    [Header("World Annotations")]
    public RoutePolyline RoutePolyline;
    
    [Header("Item Views")] 
    public StaffDataListItemView StaffDataListItemView;
    public MCPDataListItemView MCPDataListItemView;
    public VehicleDataListItemView VehicleDataListItemView;
    public SettingSectionHeader SettingSectionHeader;
    public GameObject SettingListItemView;
    public Button SettingOptionButton;
    
    // @formatter:on
}