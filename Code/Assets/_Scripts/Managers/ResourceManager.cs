using Mapbox.Map;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ResourceManager : PersistentSingleton<ResourceManager>
{
    // @formatter:off
    
    [Header("Map Entities")]
    public JanitorMapEntity JanitorMapEntity;
    public CollectorMapEntity CollectorMapEntity;
    public MCPMapEntity MCPMapEntity;
    public RoutePolyline RoutePolyline;
    
    [Header("Item Views")] 
    public StaffDataListItemView StaffDataListItemView;
    public MCPDataListItemView MCPDataListItemView;
    public VehicleDataListItemView VehicleDataListItemView;
    public InboxListItemView InboxListItemView;
    public MessageDataListItemView MessageDataListItemView;
    
    public SettingSectionHeader SettingSectionHeader;
    public GameObject SettingListItemView;
    public Button SettingOptionButton;
    
    // @formatter:on
}