public class TBSResource
{
    private TBSResourceLimiter _limiter;

    public TBSResourceData Data { get; private set; }
    public int Value { get; private set; }

    public event System.Action<int, int, TBSResourceChangeReason> ValueChanged;

    public TBSResource(TBSResourceData data, int resource)
    {
        Data = data;
        Value = resource;

        if (Data.LimiterAsset != null)
        {
            _limiter = Data.LimiterAsset.MakeLimiter();
        }
    }

    public void ChangeValue(int value, TBSResourceChangeReason reason)
    {
        switch (reason)
        {
            case TBSResourceChangeReason.Give:
                GiveValue(value);
                break;

            case TBSResourceChangeReason.Take:
                TakeValue(value);
                break;
        }
    }

    public void GiveValue(int value)
    {
        int prevValue = Value;

        if (_limiter != null)
        {
            Value = _limiter.GiveValue(Value, value);
        }
        else
        {
            Value += value;
        }

        ValueChanged?.Invoke(prevValue, Value, TBSResourceChangeReason.Give);
    }

    public void TakeValue(int value)
    {
        int prevValue = Value;

        if (_limiter != null)
        {
            Value = _limiter.TakeValue(Value, value);
        }
        else
        {
            Value -= value;
        }

        ValueChanged?.Invoke(prevValue, Value, TBSResourceChangeReason.Take);
    }

    public string GetDebug()
    {
        return $"Resource (ID: {Data.ID}, Value: {Value})";
    }
}
