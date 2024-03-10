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
        TBSTimer.Init(SettingsData.TimerData);

        TBSResourcesChangers.AddChanger(new TBSResourceChanger(TBSResourceID.Food, 1, TBSResourceChangeReason.Give));
    }

    public virtual void Destroy() 
    { 
    }
}
