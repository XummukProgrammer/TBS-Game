using UnityEngine;

[CreateAssetMenu(fileName = "Manager", menuName = "TBS/Building/Manager", order = 2)]
public class TBSBuildingManagerData : ScriptableObject
{
    [SerializeField] private TBSBuildingData[] _building;

    public TBSBuildingData GetBuildingData(TBSBuildingID id)
    {
        foreach (var building in _building)
        {
            if (building.ID == id)
            {
                return building;
            }
        }
        return null;
    }
}
