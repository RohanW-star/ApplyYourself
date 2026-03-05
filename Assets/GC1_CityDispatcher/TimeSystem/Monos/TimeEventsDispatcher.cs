
using UnityEngine;
using System;

public class TimeEventsDispatcher : MonoBehaviour
{
    // Singleton Instance
    public static TimeEventsDispatcher Instance { get; private set; }

    // Events
    public event Action<int> OnSecondsTicked;
    public event Action<int> OnMinutesTicked;
    public event Action<int> OnQuartersTicked;
    public event Action<int> OnHoursTicked;
    public event Action<int> OnDaysTicked;
    public event Action<int> OnWeeksTicked;
    public event Action<int> OnMonthsTicked;
    public event Action<int> OnYearsTicked;


    // ----------------- Functions -----------------


    private void DebugShow(int amount)
    {
        Debug.Log("Tick Amount: " + amount);
    }

    #region Awake Functions

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        // Sets up singleton logic.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes.
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances.
        }
    }

    #endregion

    #region Invoke Functions

    public void InvokeSecondsTicked(int tickAmount) => OnSecondsTicked?.Invoke(tickAmount);
    public void InvokeMinutesTicked(int tickAmount) => OnMinutesTicked?.Invoke(tickAmount);
    public void InvokeQuartersTicked(int tickAmount) => OnQuartersTicked?.Invoke(tickAmount);
    public void InvokeHoursTicked(int tickAmount) => OnHoursTicked?.Invoke(tickAmount);
    public void InvokeDaysTicked(int tickAmount) => OnDaysTicked?.Invoke(tickAmount);
    public void InvokeWeeksTicked(int tickAmount) => OnWeeksTicked?.Invoke(tickAmount);
    public void InvokeMonthsTicked(int tickAmount) => OnMonthsTicked?.Invoke(tickAmount);
    public void InvokeYearsTicked(int tickAmount) => OnYearsTicked?.Invoke(tickAmount);

    #endregion
}
