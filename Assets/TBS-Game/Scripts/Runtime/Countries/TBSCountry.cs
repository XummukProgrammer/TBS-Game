using System.Collections.Generic;

public class TBSCountry
{
    private List<TBSRegion> _regions = new();

    public TBSCountryData Data { get; private set; }

    public TBSResources Resources { get; private set; } = new();
    public List<TBSRegion>.Enumerator Regions => _regions.GetEnumerator();

    public TBSCountry(TBSCountryData data, TBSSettingsData settingsData)
    {
        Data = data;

        Resources.InitResources(settingsData.ResourcesData, data.ID.ToString());

        var regionsIDsIt = data.RegionsIDs;
        while (regionsIDsIt.MoveNext())
        {
            _regions.Add(TBSRegions.GetRegion(regionsIDsIt.Current));
        }
    }

    public void UpdateRegions()
    {
        foreach (var region in _regions)
        {
            region.UpdateCountry(this);
        }
    }
}
