using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "TBS/Building/Building", order = 1)]
public class TBSBuildingData : ScriptableObject
{
    [SerializeField] private TBSBuildingID _id;
    [SerializeField] private TBSResourceChangerAsset _resourceChangerAsset;

    public TBSBuildingID ID => _id;

    public TBSResourceChanger MakeResourceChanger()
    {
        if (_resourceChangerAsset != null)
        {
            return _resourceChangerAsset.MakeChanger();
        }
        return null;
    }
}
