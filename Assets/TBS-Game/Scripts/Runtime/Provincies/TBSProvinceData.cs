using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Province", menuName = "TBS/Provincies/Province", order = 1)]
public class TBSProvinceData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private TBSProvinceType _type;
    [SerializeField] private TBSBuildingID[] _buildings;

    public int ID => _id;
    public TBSProvinceType Type => _type;
    public List<TBSBuildingID>.Enumerator Buildings => _buildings.ToList().GetEnumerator();
}
