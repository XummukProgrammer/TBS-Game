public class TBSResourceLimiter
{
    public virtual int GiveValue(int currentValue, int value)
    {
        return currentValue + value;
    }

    public virtual int TakeValue(int currentValue, int value)
    {
        return currentValue - value;
    }
}
