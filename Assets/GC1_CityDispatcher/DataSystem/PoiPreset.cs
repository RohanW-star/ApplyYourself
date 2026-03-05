using UnityEngine;

[CreateAssetMenu(fileName = "PoiPreset", menuName = "Scriptable Objects/GameSystems/DataSystem/PoiPreset")]
public class PoiPreset : ScriptableObject
{
    [SerializeField] private string _poiName;
    [SerializeField, Range(0, 3)] private int _activeOnRound;
    [SerializeField] private EventSet _eventSet;
}
