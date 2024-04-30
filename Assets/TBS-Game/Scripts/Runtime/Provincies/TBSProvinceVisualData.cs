using UnityEngine;

[CreateAssetMenu(fileName = "ProvinceVisual", menuName = "TBS/Provincies/ProvinceVisual", order = 2)]
public class TBSProvinceVisualData : ScriptableObject
{
    [SerializeField] private string _type;
    [SerializeField] private TBSHexagonBehaviour _prefab;

    public string Type => _type;
    public TBSHexagonBehaviour Prefab => _prefab;
}
