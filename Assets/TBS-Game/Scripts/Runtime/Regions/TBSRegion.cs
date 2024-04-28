using System.Collections.Generic;

public class TBSRegion
{
    private List<TBSProvince> _provincies = new();

    public TBSRegionID ID { get; private set; }
    public List<TBSProvince>.Enumerator Provincies => _provincies.GetEnumerator();

    public void Init(TBSRegionData data)
    {
        ID = data.ID;

        var provinciesIDsIt = data.ProvinciesIDs;
        while (provinciesIDsIt.MoveNext())
        {
            _provincies.Add(TBSProvincies.GetProvince(provinciesIDsIt.Current));
        }
    }

    public void UpdateCountry(TBSCountry country)
    {
        foreach (var province in _provincies)
        {
            province.UpdateResources(country.Resources);
        }
    }
}
