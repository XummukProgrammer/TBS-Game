using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Country", menuName = "TBS/Countries/Country", order = 1)]
public class TBSCountryData : ScriptableObject
{
    [SerializeField] private TBSCountryID _id;
    [SerializeField] private TBSRegionID[] _regionsIDs;
    [SerializeField] private Color _color;

    public TBSCountryID ID => _id;
    public List<TBSRegionID>.Enumerator RegionsIDs => _regionsIDs.ToList().GetEnumerator();
    public Color Color => _color;
}
