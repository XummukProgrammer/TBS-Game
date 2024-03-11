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

        TBSProvincies.GetProvince(0).BuildingManager.AddBuilding(TBSBuildingID.Farm);
        TBSProvincies.GetProvince(1).BuildingManager.AddBuilding(TBSBuildingID.WaterTower);

        TBSCountries.Init(SettingsData);

        TBSProvincies.GetProvince(0).BuildingManager.UpdateResources(TBSCountries.GetCountry(TBSCountryID.Russian).Resources);

        TBSTimer.Init(SettingsData.TimerData);
    }

    public virtual void Destroy() 
    { 
    }
}
