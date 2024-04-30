using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Province", menuName = "TBS/Provincies/Province", order = 1)]
public class TBSProvinceData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _type;
    [SerializeField] private TBSBuildingID[] _buildings;

    public int ID => _id;
    public string Type => _type;
    public List<TBSBuildingID>.Enumerator Buildings => _buildings.ToList().GetEnumerator();

    public void Init(int id, string type)
    {
        _id = id; 
        _type = type;
        _buildings = new TBSBuildingID[1];
    }

    public void UpdateParams(string type)
    {
        _type = type;
    }
}
