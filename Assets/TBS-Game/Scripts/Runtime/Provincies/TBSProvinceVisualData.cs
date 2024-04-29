using UnityEngine;

[CreateAssetMenu(fileName = "ProvinceVisual", menuName = "TBS/Provincies/ProvinceVisual", order = 2)]
public class TBSProvinceVisualData : ScriptableObject
{
    [SerializeField] private TBSProvinceType _type;
    [SerializeField] private TBSHexagonBehaviour _prefab;

    public TBSProvinceType Type => _type;
    public TBSHexagonBehaviour Prefab => _prefab;
}
