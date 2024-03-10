using UnityEngine;

public class TBSResourceChanger
{
    private TBSResource _resource;
    private int _value;
    private TBSResourceChangeReason _reason;

    public TBSResourceChanger(TBSResourceID id, int value, TBSResourceChangeReason reason)
    {
        _resource = TBSCountry.Resources.GetResource(id);
        _value = value;
        _reason = reason;
    }

    public void Init()
    {
        TBSTimer.DayChanged += OnDayChanged;
    }

    public void Deinit()
    {
        TBSTimer.DayChanged -= OnDayChanged;
    }

    private void OnDayChanged(int day)
    {
        if (_resource != null)
        {
            _resource.ChangeValue(_value, _reason);

            Debug.Log($"Change resource: {_resource.GetDebug()}");
        }
    }
}
