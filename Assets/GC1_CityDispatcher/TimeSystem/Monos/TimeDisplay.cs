using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topTextLine;      // Early-Summer 1994
    [SerializeField] private TextMeshProUGUI _middleTextLine;   // Wednesday 28th of December
    [SerializeField] private TextMeshProUGUI _bottomTextLine;   // [13:32] oblivious afternoon

    // Top
    private string _monthlySeason = string.Empty;
    private string _worldYear = string.Empty;

    // Middle
    private string _weekDay = string.Empty;
    private string _monthDay = string.Empty;
    private string _monthDayOrdinal = string.Empty;
    private string _monthName = string.Empty;

    // Bottom
    private string _timeClock = string.Empty;
    private string _dayPhase = string.Empty;

    // Time Singletons
    private TimeWorldClock _timeWorldClock => TimeWorldClock.Instance;
    private TimeEventsDispatcher _timeEventsDispatcher => TimeEventsDispatcher.Instance;

    private void Start()
    {
        _timeEventsDispatcher.OnMinutesTicked += ResultOnMinutesTicked;
        _timeEventsDispatcher.OnHoursTicked += ResultOnHoursTicked;
        _timeEventsDispatcher.OnDaysTicked += ResultOnDaysTicked;
        _timeEventsDispatcher.OnMonthsTicked += ResultOnMonthsTicked;
        _timeEventsDispatcher.OnYearsTicked += ResultOnYearsTicked;

        GrabTimeClock();
        GrabDayPhase();
        UpdateBottomText();

        GrabWeekday();
        GrabMonthDay();
        GrabMonthName();
        UpdateMiddleText();

        GrabMonthlySeason();
        GrabWorldYear();
        UpdateTopText();
    }

    private void ResultOnMinutesTicked(int amount)
    {
        GrabTimeClock();
        UpdateBottomText();
    }

    private void ResultOnHoursTicked(int amount)
    {
        GrabDayPhase();
        UpdateBottomText();
    }

    private void ResultOnDaysTicked(int amount)
    {
        GrabWeekday();
        GrabMonthDay();
        UpdateMiddleText();
    }

    private void ResultOnMonthsTicked(int amount)
    {
        GrabMonthName();
        UpdateMiddleText();

        GrabMonthlySeason();
        UpdateTopText();
    }

    private void ResultOnYearsTicked(int amount)
    {
        GrabWorldYear();
        UpdateTopText();
    }

    #region Bottom

    private void GrabTimeClock()
    {
        _timeClock = _timeWorldClock.GetCurrentTimeToString_HM();
    }

    private void GrabDayPhase()
    {
        _dayPhase = _timeWorldClock.GetCurrentHourSet().dayphase.dayphaseName;
    }

    private void UpdateBottomText()
    {
        _bottomTextLine.text = $"{_timeClock} {_dayPhase}";
    }

    #endregion

    #region Middle

    private void GrabWeekday()
    {
        _weekDay = _timeWorldClock.GetCurrentWeekdaySet().weekDayName;
    }

    private void GrabMonthDay()
    {
        int day = _timeWorldClock.GetCurrentMonthDay();
        _monthDay = day.ToString();
        _monthDayOrdinal = CalculateOrdinal(day);
    }

    private void GrabMonthName()
    {
        _monthName = _timeWorldClock.GetCurrentMonthSet().monthName;
    }

    private void UpdateMiddleText()
    {
        _middleTextLine.text = $"{_weekDay} {_monthDay}{_monthDayOrdinal} of {_monthName}";
    }

    #endregion

    #region Top

    private void GrabMonthlySeason()
    {
        _monthlySeason = _timeWorldClock.GetCurrentMonthSet().monthSeason.seasonName;
    }

    private void GrabWorldYear()
    {
        _worldYear = _timeWorldClock.GetCurrentYear().ToString();
    }

    private void UpdateTopText()
    {
        _topTextLine.text = $"{_monthlySeason} {_worldYear}";
    }

    #endregion

    string CalculateOrdinal(int number)
    {
        if (number <= 0) return "";

        int mod100 = number % 100;
        if (mod100 is 11 or 12 or 13) return "th";

        return (number % 10) switch
        {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th"
        };
    }
}
