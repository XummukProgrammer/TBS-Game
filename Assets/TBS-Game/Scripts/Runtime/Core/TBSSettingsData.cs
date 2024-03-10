using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "TBS/Core/Settings", order = 2)]
public class TBSSettingsData : ScriptableObject
{
    [SerializeField] private TBSMapData _mapData;
    [SerializeField] private TBSResourcesData _resourcesData;
    [SerializeField] private TBSTimerData _timerData;

    public TBSMapData MapData => _mapData;
    public TBSResourcesData ResourcesData => _resourcesData;
    public TBSTimerData TimerData => _timerData;
}
