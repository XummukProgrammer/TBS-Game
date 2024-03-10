using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Countries", menuName = "TBS/Countries/Countries", order = 2)]
public class TBSCountriesData : ScriptableObject
{
    [SerializeField] private TBSCountryData[] _countries;

    public List<TBSCountryData>.Enumerator Countries => _countries.ToList().GetEnumerator();

    public TBSCountryData GetCountryData(TBSCountryID id)
    {
        foreach (var country in _countries)
        {
            if (country.ID == id)
            {
                return country;
            }
        }
        return null;
    }
}
