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

        TBSProvincies.Init(SettingsData.ProvinciesData, SettingsData.BuildingManagerData);
        TBSRegions.Init(SettingsData.RegionsData);

        TBSCountries.Init(SettingsData);

        TBSTimer.Init(SettingsData.TimerData);
    }

    public virtual void Destroy() 
    { 
    }
}
