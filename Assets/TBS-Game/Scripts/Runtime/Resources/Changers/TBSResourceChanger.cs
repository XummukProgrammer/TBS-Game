using UnityEngine;

public class TBSResourceChanger
{
    private TBSResourceID _id;
    private TBSResource _resource;
    private int _value;
    private TBSResourceChangeReason _reason;
    private TBSResources _resources;

    public TBSResourceChanger(TBSResourceID id, int value, TBSResourceChangeReason reason)
    {
        _id = id;
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

    public void UpdateResources(TBSResources resources)
    {
        _resources = resources;
        _resource = _resources.GetResource(_id);
    }

    private void OnDayChanged(int day)
    {
        if (_resource != null)
        {
            _resource.ChangeValue(_value, _reason);

            Debug.Log($"Change resource: {_resource.GetDebug()}, Owner: {_resources.Owner}");
        }
    }
}
