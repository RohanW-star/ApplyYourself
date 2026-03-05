using System;
using UnityEngine;

[Serializable]
public class GameVariableClass
{
    [SerializeField] private GameVariableDisplay _display;

    [SerializeField] private float _startValue;
    [SerializeField] private float _startMaxValue;

    [SerializeField] private float _currentValue;
    [SerializeField] private float _currentMaxValue;
    private float _currentThressholdValue;

    public float CurrentValue
    {
        get
        {
            return _currentValue;
        }
        set
        {
            float preValue = _currentValue;
            _currentValue = value;
            if (preValue != _currentValue)
                DisplayValue();
        }
    }
    public float CurrentMaxValue
    {
        get
        {
            return _currentMaxValue;
        }
        set
        {
            float preValue = _currentMaxValue;
            _currentMaxValue = value;
            if (preValue != _currentMaxValue)
                DisplayValue();
        }
    }
    public float CurrentThressholdValue
    {
        get
        {
            return _currentThressholdValue;
        }
        set
        {
            float preValue = _currentThressholdValue;
            _currentThressholdValue = value;
            if (preValue != _currentThressholdValue)
                DisplayValue();
        }
    }

    public void Restart()
    {
        _currentValue = _startValue;
        _currentMaxValue = _startMaxValue;

        DisplayValue();
    }

    public bool AddCurrentValue(float amount)
    {
        float preValue = _currentValue;
        _currentValue += amount;

        if (_currentMaxValue != 0 && _currentValue > _currentMaxValue)
        {
            _currentValue = _currentMaxValue;
            return true;
        }

        if (preValue != _currentValue)
        {
            DisplayValue();
        }

        // Didn't hit max, so not full yet.
        return false;
    }

    public bool SubtractCurrentValue(float amount)
    {
        float preValue = _currentValue;
        _currentValue -= amount;

        if (_currentValue < 0)
        {
            _currentValue = 0;
            return true;
        }

        if (preValue != _currentValue)
            DisplayValue();

        // Didn't hit below zero, so not empty yet.
        return false;
    }

    public void AddMaxValue(float amount)
    {
        float preValue = _currentMaxValue;
        _currentMaxValue += amount;

        if (preValue != _currentMaxValue)
            DisplayValue();
    }

    public void SubtractMaxValue(float amount)
    {
        float preValue = _currentMaxValue;
        _currentMaxValue -= amount;

        // Downgrade current if to big!
        if (_currentValue > _currentMaxValue)
            _currentValue = _currentMaxValue;

        if (preValue != _currentMaxValue)
            DisplayValue();
    }

    private void DisplayValue()
    {
        if (_currentMaxValue == 0)
            _display.SetSingleValue(_currentValue);
        else
            _display.SetCombinedValue(_currentValue, _currentMaxValue);
    }
}