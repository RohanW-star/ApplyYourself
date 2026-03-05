// [Summary] (By Wessel)
//
// This script is for creating data presets of time based variabled.
//

// Namespaces:
using UnityEngine;
using System.Collections.Generic;

// Scriptable class:
[CreateAssetMenu(fileName = "TimeDayphaseSet", menuName = "Scriptable Objects/GameSystems/TimeSystem/TimeDayphaseSet")]
public class TimeDayphaseSet : ScriptableObject
{
    public string dayphaseName;
    public int durationInHours;
    public List<TimeDailyMoodSet> possibleDailyMoods; 
}