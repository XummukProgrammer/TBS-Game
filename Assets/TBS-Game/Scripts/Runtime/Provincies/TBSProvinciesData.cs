using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Provincies", menuName = "TBS/Provincies/Provincies", order = 3)]
public class TBSProvinciesData : ScriptableObject
{
    [SerializeField] private TBSProvinceData[] _provincies;
    [SerializeField] private TBSProvinceData _defaultProvince;
    [SerializeField] private TBSProvinceVisualData[] _visuals;

    public TBSProvinceData DefaultProvince => _defaultProvince;

    public List<TBSProvinceData>.Enumerator Provincies => _provincies.ToList().GetEnumerator();
    public List<TBSProvinceVisualData>.Enumerator Visuals => _visuals.ToList().GetEnumerator();
    public List<string> ProvinciesTypes => GetProvinciesTypes();

    public TBSProvinceData GetProvince(int id)
    {
        var province = _provincies.ToList().Find(province => province.ID == id);
        if (province != null)
        {
            return province;
        }
        return _defaultProvince;
    }

    public TBSProvinceVisualData GetVisual(string type)
    {
        return _visuals.ToList().Find(visual => visual.Type == type);
    }

    public void AddProvice(TBSProvinceData province)
    {
        TBSArraysHelper.AddValueInArray(ref _provincies, province);
    }

    private List<string> GetProvinciesTypes()
    {
        var types = new List<string>();

        foreach (var visual in _visuals)
        {
            types.Add(visual.Type);
        }

        return types;
    }
}
