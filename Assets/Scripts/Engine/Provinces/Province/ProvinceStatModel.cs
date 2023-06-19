using System;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceStatModel
{
    private float _value;
    private float _positiveDelta;
    private float _negativeDelta;
    private float _limitValueModifierNegative;
    private float _limitValueModifierPositive;
    private float _centrifugalCoefficient;
    private float _centralValue;

    private const float _minValue = 0;
    private const float _maxValue = 100;

    public float Value { get { return _value; } private set { _value = Mathf.Clamp(value, _minValue, _maxValue); } }

    public ProvinceStatModel(float centralValue = 0, float limitValueModifierNegative = 0.05f, float limitValueModifierPositive = 0.05f, float centrifugalCoefficient = 0.05f)
    {
        if (centralValue < _minValue || centralValue > _maxValue)
            throw new ArgumentException($"centralValue must be between {_minValue} and {_maxValue}.");
        
        _centralValue = centralValue;
        _limitValueModifierNegative = limitValueModifierNegative;
        _limitValueModifierPositive = limitValueModifierPositive;
        _centrifugalCoefficient = centrifugalCoefficient;
        _value = _centralValue;
    }

    public void Increase(float value)
    {
        if (value < 0)
            throw new ArgumentException("value must be positive.");

        _positiveDelta += value;
    }

    public void Decrease(float value)
    {
        if (value < 0)
            throw new ArgumentException("value must be positive.");

        _negativeDelta += value;
    }

    public void Update()
    {
        float deviation = _value - _centralValue;

        ApplyDeltas(deviation);

        ApplyCentrifugalForce();

        ClampValueWithinLimits();
    }

    private void ApplyDeltas(float deviation)
    {
        _value += _positiveDelta * (_limitValueModifierPositive * deviation);
        _value -= _negativeDelta * (_limitValueModifierNegative * deviation);

        _positiveDelta = 0;
        _negativeDelta = 0;
    }

    private void ApplyCentrifugalForce()
    {
        _value += _centrifugalCoefficient * (_centralValue - _value);
    }

    private void ClampValueWithinLimits()
    {
        Value = _value;
    }
}
