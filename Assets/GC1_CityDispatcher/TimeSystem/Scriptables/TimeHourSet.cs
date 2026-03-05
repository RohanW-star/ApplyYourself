// [Summary] (By Wessel)
//
// This script is for creating data presets of time based variabled.
//

// Namespaces:
using UnityEngine;

// Scriptable class:
[CreateAssetMenu(fileName = "TimeHourSet", menuName = "Scriptable Objects/GameSystems/TimeSystem/TimeHourSet")]
public class TimeHourSet : ScriptableObject
{
    public TimeDayphaseSet dayphase;
}