using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Region", menuName = "TBS/Regions/Region", order = 1)]
public class TBSRegionData : ScriptableObject
{
    [SerializeField] private TBSRegionID _id;
    [SerializeField] private int[] _provinciesIDs;

    public TBSRegionID ID => _id;
    public List<int>.Enumerator ProvinciesIDs => _provinciesIDs.ToList().GetEnumerator();
}
