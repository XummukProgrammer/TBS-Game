using UnityEngine;

[CreateAssetMenu(fileName = "BaseLimiter", menuName = "TBS/Resources/Limiters/Base", order = 1)]
public class TBSResourceLimiterAsset : ScriptableObject
{
    public virtual TBSResourceLimiter MakeLimiter() { return new TBSResourceLimiter(); }
}
