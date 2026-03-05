
// [Summary] (By Wessel)
//
// This script is for creating data presets of time based variabled.
//

// Namespaces:
using System;
using System.Collections.Generic;
using UnityEngine;

// Scriptable class:
[CreateAssetMenu(fileName = "TimeRulesPreset", menuName = "Scriptable Objects/GameSystems/TimeSystem/TimeRulesPreset")]
public class TimeRulesPreset : ScriptableObject
{
    // ----------------- Variables -----------------

    [Header("Daily Variables")]
    public int secondsPerMinute = 60;
    public int minutesPerQuarter = 15;
    public int quartersPerHour = 4;
    public int minutesPerHour = 60;

    [Header("Common Year Variables")]
    public int daysPerCommonYear = 365;
    public int weeksPerCommonYear = 52;
    public int remainingDaysAfterWeeksPerCommonYear = 2;

    [Header("Leap Year Variables")]
    public int daysPerLeapYear = 366;
    public int weeksPerLeapYear = 52;
    public int remainingDaysAfterWeeksPerLeapYear = 3;
    public int LeapYearEveryDivisible = 4;
    public int skipLeapYearsDivisibleBy = 100;
    public int unskipLeapYearsDivisibleBy = 400;

    [Header("Hourly Variables")]
    public List<TimeHourSet> hoursPerDay = new();

    [Header("Weekly Variables")]
    public List<TimeWeekdaySet> daysPerWeek = new();

    [Header("Monthly Variables")]
    public List<TimeMonthSet> monthsPerYear = new();
}