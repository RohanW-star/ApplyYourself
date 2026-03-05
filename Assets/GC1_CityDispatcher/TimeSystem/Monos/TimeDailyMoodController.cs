using System;
using UnityEngine;

public class TimeDailyMoodController : MonoBehaviour
{
    [SerializeField] private TimeDailyMoodSet currentDailyMoodSet;

    TimeDayphaseSet currentDayphase;
    TimeDailyMoodSet currentDailyMood;

    public event Action<TimeDailyMoodSet> OnDailyMoodChanged;

    // Time Singletons
    private TimeWorldClock _timeWorldClock => TimeWorldClock.Instance;
    private TimeEventsDispatcher _timeEventsDispatcher => TimeEventsDispatcher.Instance;

    private void Start()
    {
        _timeEventsDispatcher.OnHoursTicked += ResultOnHoursTicked;
        CheckPhaseChange();
    }

    private void ResultOnHoursTicked(int amount)
    {
        CheckPhaseChange();
    }

    private void CheckPhaseChange()
    {
        TimeDayphaseSet phase = _timeWorldClock.GetCurrentHourSet().dayphase;
        if (currentDayphase == phase)
            return;
        currentDayphase = phase;

        GrabRandomDailyMood();
    }

    private void GrabRandomDailyMood()
    {
        TimeDailyMoodSet before = currentDailyMood;
        int max = currentDayphase.possibleDailyMoods.Count;
        int random = UnityEngine.Random.Range(0, max);
        currentDailyMood = currentDayphase.possibleDailyMoods[random];

        if (before != currentDailyMood)
            OnDailyMoodChanged(currentDailyMood);
    }
}
