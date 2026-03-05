// [Summary] (By Wessel)
//
// This script is for creating data presets of time based variabled.
//

// Namespaces:
using UnityEngine;

// Scriptable class:
[CreateAssetMenu(fileName = "TimeWeekPreset", menuName = "Scriptable Objects/GameSystems/TimeSystem/TimeWeekPreset")]
public class TimeWeekdaySet : ScriptableObject
{
    public string weekDayName;
    public string weekDayShortest;
    public bool isWeekend;
}