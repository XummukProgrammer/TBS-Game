using UnityEngine;

[CreateAssetMenu(fileName = "MinMax", menuName = "TBS/Resources/Limiters/MinMax", order = 2)]
public class TBSResourceMinMaxLimiterAsset : TBSResourceLimiterAsset
{
    [SerializeField] private int _min = 0;
    [SerializeField] private int _max = 1000;

    public override TBSResourceLimiter MakeLimiter()
    {
        return new TBSResourceMinMaxLimiter(_min, _max);
    }
}
