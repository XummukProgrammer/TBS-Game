using System.Collections.Generic;

public static class TBSRegions
{
    private static List<TBSRegion> _regions = new();

    public static void Init(TBSRegionsData regionsData)
    {
        var regionsIt = regionsData.Regions;
        while (regionsIt.MoveNext())
        {
            var newRegion = new TBSRegion();
            newRegion.Init(regionsIt.Current);

            _regions.Add(newRegion);
        }
    }

    public static TBSRegion GetRegion(TBSRegionID id)
    {
        return _regions.Find(region => region.ID == id);
    }
}
