
// [Summary] (By Wessel)
//
// This script is in charge of keeping track of time and updating it as it progresses,
// serving as a nice central basis for other scripts to operate on.
//

// [To Do]
//
// > Add more time variables from the worlds time rules.
//

// Namespaces:
using Unity.VisualScripting;
using UnityEngine;

// Mono class:
public class TimeWorldClock : MonoBehaviour
{
    // ----------------- Variables -----------------

    [Header("Update Variables")]
    [Tooltip("Is time allowed to move?"), SerializeField] private bool timeForcedStop = false;
    [Tooltip("The game speed that effects multiplication"), SerializeField] private float timeGameSpeed = 1f;
    [Tooltip("The multiplication of time every second"), SerializeField] private float timeMultiplier;

    [Header("Preset Variables")]
    [Tooltip("The preset holding all the time rules"), SerializeField] private TimeRulesPreset _timeRulesPreset;

    [Header("Second Based Variables")]
    [SerializeField] private int currentSeconds;

    [Header("Minute Based Variables")]
    [SerializeField] private int currentMinutes;

    [Header("Day Based Variables")]
    [SerializeField] private int currentDays;

    [Header("Week Variables")]
    [SerializeField] private int currentWeek;

    [Header("Year Variables")]
    [SerializeField] private int currentYear;
    [SerializeField] private int currentDayOfYear;
    [SerializeField] private bool isCurrentlyLeapYear;

    [Header("Index Variables")]
    [SerializeField] private int currentQuarterIndex;     // Index of the current quarter of the hour.
    [SerializeField] private int currentHoursIndex;       // Index of the current hour of the day.
    [SerializeField] private int currentWeekDayIndex;     // Index of the current day of the week.
    [SerializeField] private int currentMonthIndex;       // Index of the current month of the year.
    [SerializeField] private int currentMonthDayIndex;    // Index of the current day in the month.

    [Header("Current SO Sets")]
    [SerializeField] private TimeHourSet currentHourSet;
    [SerializeField] private TimeWeekdaySet currentWeekDaySet;
    [SerializeField] private TimeMonthSet currentMonthSet;

    #region Private Calculated Variables

    // Singleton Instance
    public static TimeWorldClock Instance { get; private set; }

    // Event Dispatchers
    private TimeEventsDispatcher _timeEventsDispatcherInstance => TimeEventsDispatcher.Instance;

    // For Updating Logic
    private float timeAccumulator = 0f;

    #endregion


    // ----------------- Functions -----------------

    public void ForceStopTime(bool direction)
    {
        timeForcedStop = direction;
    }

    public void SetGameSpeed(float speed)
    {
        timeGameSpeed = speed;
    }

    #region Getter Functions

    // Get the current time in form of a string.
    public int GetCurrentMonthDay() => currentMonthDayIndex;
    public int GetCurrentYear() => currentYear;
    public int GetCurrentQuarterIndex() => currentQuarterIndex;
    public int GetCurrentHour() => currentHoursIndex;
    public string GetCurrentTimeToString_HMS() => $"[{currentHoursIndex:00}:{currentMinutes:00}:{currentSeconds:00}]";
    public string GetCurrentTimeToString_HM() => $"[{currentHoursIndex:00}:{currentMinutes:00}]";
    public TimeHourSet GetCurrentHourSet() => currentHourSet;
    public TimeWeekdaySet GetCurrentWeekdaySet() => currentWeekDaySet;
    public TimeMonthSet GetCurrentMonthSet() => currentMonthSet;

    #endregion

    #region Awake Functions

    private void Awake()
    {
        Singleton();
        Setup();
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

    private void Setup()
    {
        GrabCurrentWeekDaySet();
        GrabCurrentMonthSet();
        GrabCurrentHourSet();
    }

    #endregion

    #region Update Functions

    // Updating clock
    private void Update()
    {
        // Is time allowed to run?
        if (timeForcedStop)
            return;

        // Accumulate scaled deltaTime
        timeAccumulator += Time.deltaTime * timeMultiplier * timeGameSpeed;

        // How many full seconds have passed
        int fullSeconds = Mathf.FloorToInt(timeAccumulator);
        if (fullSeconds == 0) return;

        // Advance the clock once, with full multiplier
        AdvanceOneSecond(fullSeconds);

        // Subtract the full seconds from the accumulator
        timeAccumulator -= fullSeconds;
    }

    private void AdvanceOneSecond(int secondsMultiplier)
    {
        int secondsAdvanced = secondsMultiplier;
        int minutesAdvanced = 0;
        int quartersAdvanced = 0;
        int hoursAdvanced = 0;
        int daysAdvanced = 0;
        int weeksAdvanced = 0;
        int monthsAdvanced = 0;
        int yearsAdvanced = 0;

        // Seconds
        currentSeconds += secondsAdvanced;
        if (currentSeconds >= _timeRulesPreset.secondsPerMinute)
        {
            minutesAdvanced = currentSeconds / _timeRulesPreset.secondsPerMinute;
            currentSeconds %= _timeRulesPreset.secondsPerMinute;

            // Minutes
            currentMinutes += minutesAdvanced;

            // Quarters
            int previousQuarter = currentQuarterIndex;
            currentQuarterIndex = currentMinutes / _timeRulesPreset.minutesPerQuarter;
            quartersAdvanced = currentQuarterIndex - previousQuarter;
            if (quartersAdvanced < 0)
                quartersAdvanced += _timeRulesPreset.quartersPerHour;

            if (currentMinutes >= _timeRulesPreset.minutesPerHour)
            {
                // Hours
                hoursAdvanced = currentMinutes / _timeRulesPreset.minutesPerHour;
                currentMinutes %= _timeRulesPreset.minutesPerHour;
                currentHoursIndex += hoursAdvanced;

                if (currentHoursIndex >= _timeRulesPreset.hoursPerDay.Count)
                {
                    // Days
                    daysAdvanced = currentHoursIndex / _timeRulesPreset.hoursPerDay.Count;
                    currentHoursIndex %= _timeRulesPreset.hoursPerDay.Count;
                    currentDays += daysAdvanced;
                    currentDayOfYear += daysAdvanced;

                    // Weeks
                    int totalWeekDays = currentWeekDayIndex + daysAdvanced;
                    currentWeekDayIndex = totalWeekDays % _timeRulesPreset.daysPerWeek.Count;
                    weeksAdvanced = totalWeekDays / _timeRulesPreset.daysPerWeek.Count;
                    if (daysAdvanced > 0)
                        GrabCurrentWeekDaySet();

                    // Months
                    int remainingDays = currentMonthDayIndex + daysAdvanced;
                    int monthIndex = currentMonthIndex;
                    int year = currentYear;
                    bool leap = isCurrentlyLeapYear;

                    // Years
                    while (true)
                    {
                        int daysInMonth = leap ?
                            _timeRulesPreset.monthsPerYear[monthIndex].amountOfLeapYearDays :
                            _timeRulesPreset.monthsPerYear[monthIndex].amountOfCommonYearDays;

                        if (remainingDays <= daysInMonth)
                            break;

                        remainingDays -= daysInMonth;
                        monthIndex++;
                        monthsAdvanced++;
                        GrabCurrentMonthSet();

                        if (monthIndex >= _timeRulesPreset.monthsPerYear.Count)
                        {
                            monthIndex -= _timeRulesPreset.monthsPerYear.Count;
                            year++;
                            leap = IsLeapYear(year);
                            yearsAdvanced++;
                            currentDayOfYear = 0;
                        }
                    }

                    currentMonthIndex = monthIndex;
                    currentMonthDayIndex = remainingDays;
                    currentYear = year;
                    isCurrentlyLeapYear = leap;
                }

                if (hoursAdvanced > 0)
                    GrabCurrentHourSet();
            }
        }

        // Invoke events with amounts
        if (secondsAdvanced > 0) _timeEventsDispatcherInstance.InvokeSecondsTicked(secondsAdvanced);
        if (quartersAdvanced > 0) _timeEventsDispatcherInstance.InvokeQuartersTicked(quartersAdvanced);
        if (minutesAdvanced > 0) _timeEventsDispatcherInstance.InvokeMinutesTicked(minutesAdvanced);
        if (hoursAdvanced > 0) _timeEventsDispatcherInstance.InvokeHoursTicked(hoursAdvanced);
        if (daysAdvanced > 0) _timeEventsDispatcherInstance.InvokeDaysTicked(daysAdvanced);
        if (weeksAdvanced > 0) _timeEventsDispatcherInstance.InvokeWeeksTicked(weeksAdvanced);
        if (monthsAdvanced > 0) _timeEventsDispatcherInstance.InvokeMonthsTicked(monthsAdvanced);
        if (yearsAdvanced > 0) _timeEventsDispatcherInstance.InvokeYearsTicked(yearsAdvanced);
    }

    private bool IsLeapYear(int year)
    {
        if (year % _timeRulesPreset.unskipLeapYearsDivisibleBy == 0)
            return true;

        if (year % _timeRulesPreset.skipLeapYearsDivisibleBy == 0)
            return false;

        return year % _timeRulesPreset.LeapYearEveryDivisible == 0;
    }

    #endregion

    #region Grab Functions

    private void GrabCurrentWeekDaySet()
    {
        currentWeekDaySet = _timeRulesPreset.daysPerWeek[currentWeekDayIndex];
    }

    private void GrabCurrentMonthSet()
    {
        currentMonthSet = _timeRulesPreset.monthsPerYear[currentMonthIndex];
    }

    private void GrabCurrentHourSet()
    {
        currentHourSet = _timeRulesPreset.hoursPerDay[currentHoursIndex];
    }

    #endregion
}
