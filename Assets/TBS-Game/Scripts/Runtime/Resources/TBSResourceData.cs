using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "TBS/Resources/Resource", order = 2)]
public class TBSResourceData : ScriptableObject
{
    [SerializeField] private TBSResourceID _id;
    [SerializeField] private Transform _prefab;
    [SerializeField] private TBSResourceLimiterAsset _limiterAsset;

    public TBSResourceID ID => _id;
    public Transform Prefab => _prefab;
    public TBSResourceLimiterAsset LimiterAsset => _limiterAsset;
}
