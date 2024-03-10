using UnityEngine;

[CreateAssetMenu(fileName = "Timer", menuName = "TBS/Timer/Timer", order = 1)]
public class TBSTimerData : ScriptableObject
{
    [SerializeField] private int _startDay;
    [SerializeField] private float _intervalBetweenDay;

    public int StartDay => _startDay;
    public float IntervalBetweenDay => _intervalBetweenDay;
}
