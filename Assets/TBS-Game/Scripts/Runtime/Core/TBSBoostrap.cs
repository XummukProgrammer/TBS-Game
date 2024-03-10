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

        TBSCountry.Resources.InitResources(SettingsData.ResourcesData);
        TBSCountry.BuildingManager.Init(SettingsData.BuildingManagerData);

        TBSCountry.BuildingManager.AddBuilding(TBSCountry.BuildingManager.MakeBuilding(TBSBuildingID.Farm));
        TBSCountry.BuildingManager.AddBuilding(TBSCountry.BuildingManager.MakeBuilding(TBSBuildingID.WaterTower));

        TBSTimer.Init(SettingsData.TimerData);
    }

    public virtual void Destroy() 
    { 
    }
}
