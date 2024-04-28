public class TBSBoostrap
{
    protected TBSSettingsData SettingsData { get; private set; }
    protected TBSLinksBehaviour LinksBehaviour { get; private set; }

    public TBSBoostrap(TBSSettingsData settingsData, TBSLinksBehaviour linksBehaviour)
    {
        SettingsData = settingsData;
        LinksBehaviour = linksBehaviour;
    }

    public virtual void Setup() 
    {
        TBSMap.Init(LinksBehaviour.MapBehaviour, SettingsData.MapData);
        TBSMap.GenerateHexagons();
        TBSMap.InitHexagons();

        TBSProvincies.Init(SettingsData.BuildingManagerData);
        TBSRegions.Init(SettingsData.RegionsData);

        TBSProvincies.GetProvince(0).BuildingManager.AddBuilding(TBSBuildingID.Farm);
        TBSProvincies.GetProvince(1).BuildingManager.AddBuilding(TBSBuildingID.WaterTower);

        TBSProvincies.GetProvince(2).BuildingManager.AddBuilding(TBSBuildingID.Farm);
        TBSProvincies.GetProvince(3).BuildingManager.AddBuilding(TBSBuildingID.WaterTower);

        TBSCountries.Init(SettingsData);

        TBSTimer.Init(SettingsData.TimerData);
    }

    public virtual void Destroy() 
    { 
    }
}
