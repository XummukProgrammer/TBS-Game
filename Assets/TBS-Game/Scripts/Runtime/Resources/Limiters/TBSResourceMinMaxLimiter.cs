using UnityEngine;

public class TBSResourceMinMaxLimiter : TBSResourceLimiter
{
    private int _min;
    private int _max;

    public TBSResourceMinMaxLimiter(int min, int max)
    {
        _min = min; 
        _max = max;
    }

    public override int GiveValue(int currentValue, int value)
    {
        return Mathf.Clamp(currentValue + value, _min, _max);
    }

    public override int TakeValue(int currentValue, int value)
    {
        return Mathf.Clamp(currentValue - value, _min, _max);
    }
}
