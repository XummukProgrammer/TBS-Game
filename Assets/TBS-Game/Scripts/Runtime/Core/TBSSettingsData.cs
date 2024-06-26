using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "TBS/Core/Settings", order = 2)]
public class TBSSettingsData : ScriptableObject
{
    [SerializeField] private TBSMapData _mapData;
    [SerializeField] private TBSResourcesData _resourcesData;
    [SerializeField] private TBSTimerData _timerData;
    [SerializeField] private TBSBuildingManagerData _buildingManagerData;
    [SerializeField] private TBSCountriesData _countriesData;
    [SerializeField] private TBSRegionsData _regionsData;
    [SerializeField] private TBSProvinciesData _provinciesData;

    public TBSMapData MapData => _mapData;
    public TBSResourcesData ResourcesData => _resourcesData;
    public TBSTimerData TimerData => _timerData;
    public TBSBuildingManagerData BuildingManagerData => _buildingManagerData;
    public TBSCountriesData CountriesData => _countriesData;
    public TBSRegionsData RegionsData => _regionsData;
    public TBSProvinciesData ProvinciesData => _provinciesData;
}
