public class TBSCountry
{
    public TBSCountryData Data { get; private set; }

    public TBSResources Resources { get; private set; } = new();
    public TBSBuildingManager BuildingManager { get; private set; } = new();

    public TBSCountry(TBSCountryData data, TBSSettingsData settingsData)
    {
        Data = data;

        Resources.InitResources(settingsData.ResourcesData);
        BuildingManager.Init(settingsData.BuildingManagerData);

        BuildingManager.AddBuilding(BuildingManager.MakeBuilding(Resources, TBSBuildingID.Farm));
        BuildingManager.AddBuilding(BuildingManager.MakeBuilding(Resources, TBSBuildingID.WaterTower));
    }
}
