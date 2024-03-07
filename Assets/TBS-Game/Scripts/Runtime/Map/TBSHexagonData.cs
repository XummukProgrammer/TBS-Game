using UnityEngine;

[CreateAssetMenu(fileName = "Hexagon", menuName = "TBS/Map/Hexagon", order = 2)]
public class TBSHexagonData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private TBSHexagonBehaviour _prefab;

    public int ID => _id;
    public TBSHexagonBehaviour Prefab => _prefab;
}
