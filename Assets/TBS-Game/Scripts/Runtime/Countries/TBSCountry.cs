public class TBSCountry
{
    public TBSCountryData Data { get; private set; }

    public TBSResources Resources { get; private set; } = new();

    public TBSCountry(TBSCountryData data, TBSSettingsData settingsData)
    {
        Data = data;

        Resources.InitResources(settingsData.ResourcesData);
    }
}
