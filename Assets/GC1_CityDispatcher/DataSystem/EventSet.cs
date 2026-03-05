using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSet", menuName = "Scriptable Objects/GameSystems/DataSystem/EventSet")]
public class EventSet : ScriptableObject
{
    [SerializeField, TextArea(5, 20)] private string _prechosenDescription;
    [SerializeField, TextArea(5, 20)] private string _chosenDescription;
    [SerializeField] private List<OptionSet> _optionSets;
}