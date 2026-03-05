using UnityEngine;

[CreateAssetMenu(fileName = "OptionSet", menuName = "Scriptable Objects/GameSystems/DataSystem/OptionSet")]
public class OptionSet : ScriptableObject
{
    [SerializeField] private string _optionTitle = "OPTION";
    [SerializeField, TextArea(5, 20)] private string _optionDescription;
}
