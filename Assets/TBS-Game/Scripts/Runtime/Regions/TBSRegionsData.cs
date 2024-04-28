using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Regions", menuName = "TBS/Regions/Regions", order = 2)]
public class TBSRegionsData : ScriptableObject
{
    [SerializeField] private TBSRegionData[] _regions;

    public List<TBSRegionData>.Enumerator Regions => _regions.ToList().GetEnumerator();

    public TBSRegionData GetRegion(TBSRegionID id)
    {
        return _regions.ToList().Find(region => region.ID == id);
    }
}
