using UnityEngine;

public static class TBSTimer
{
    public static int Day { get; private set; }
    public static float IntervalBetweenDay { get; private set; }

    private static float _time;

    public static event System.Action<int> DayChanged;
    public static event System.Action<int> PostDayChanged;

    public static void Init(TBSTimerData data)
    {
        Day = data.StartDay;
        IntervalBetweenDay = data.IntervalBetweenDay;

        _time = 0;
    }

    public static void OnUpdate()
    {
        _time += Time.deltaTime;

        if (_time >= IntervalBetweenDay)
        {
            _time = 0;
            Day++;

            DayChanged?.Invoke(Day);
            Debug.Log($"Day changed: {Day}");

            PostDayChanged?.Invoke(Day);
        }
    }
}
