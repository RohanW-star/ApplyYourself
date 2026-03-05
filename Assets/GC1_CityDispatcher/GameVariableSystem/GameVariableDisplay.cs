using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameVariableDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDisplay;

    [SerializeField] private string _preAddToString;
    [SerializeField] private string _postAddToString;
    [SerializeField] private string _middleAddToString;
    [SerializeField] private Slider _percentageSlider;
    [SerializeField] private Image _sliderImage;
    [SerializeField] private Color _sliderColor;
    public void SetSingleValue(float value)
    {
        string text = _preAddToString + RoundValue(value) + _postAddToString;
        DisplayText(text);
    }

    public void SetCombinedValue(float mainValue, float endValue)
    {
        string text = _preAddToString + RoundValue(mainValue) + _middleAddToString + RoundValue(endValue) + _postAddToString;
        DisplayText(text);
        ApplySlider(mainValue, endValue);
    }

    private void DisplayText(string newText)
    {
        _textDisplay.text = newText;
    }

    private string RoundValue(float value)
    {
        return Mathf.FloorToInt(value).ToString();
    }

    private void ApplySlider(float value, float max)
    {
        _percentageSlider.maxValue = max;
        _percentageSlider.value = value;
        _sliderImage.color = _sliderColor;
    }
}
