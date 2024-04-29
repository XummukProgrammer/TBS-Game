using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Provincies", menuName = "TBS/Provincies/Provincies", order = 2)]
public class TBSProvinciesData : ScriptableObject
{
    [SerializeField] private TBSProvinceData[] _provincies;

    public List<TBSProvinceData>.Enumerator Provincies => _provincies.ToList().GetEnumerator();

    public TBSProvinceData GetProvince(int id)
    {
        return _provincies.ToList().Find(province => province.ID == id);
    }
}
