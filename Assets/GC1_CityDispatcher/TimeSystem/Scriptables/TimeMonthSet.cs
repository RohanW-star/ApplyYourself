// [Summary] (By Wessel)
//
// This script is for creating data presets of time based variabled.
//

// Namespaces:
using UnityEngine;

// Scriptable class:
[CreateAssetMenu(fileName = "TimeMonthPreset", menuName = "Scriptable Objects/GameSystems/TimeSystem/TimeMonthPreset")]
public class TimeMonthSet : ScriptableObject
{
    public TimeSeasonSet monthSeason;
    public string monthName;
    public string monthNameShortest;
    public int amountOfCommonYearDays;
    public int amountOfLeapYearDays;
}