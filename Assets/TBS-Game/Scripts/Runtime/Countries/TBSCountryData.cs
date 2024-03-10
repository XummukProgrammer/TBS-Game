using UnityEngine;

[CreateAssetMenu(fileName = "Country", menuName = "TBS/Countries/Country", order = 1)]
public class TBSCountryData : ScriptableObject
{
    [SerializeField] private TBSCountryID _id;

    public TBSCountryID ID => _id;
}
