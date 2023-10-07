using System;
using CaronixTest.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CaronixTest.ScriptableObjects
{
    [Serializable]
    public class IntervalData
    {
        [SerializeField] private ValueTypes _type;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        public ValueTypes Type => _type;

        private void OnValidate()
        {
            if (_minValue > _maxValue)
            {
                _minValue = _maxValue;
            }
        }

        public int GetRandomValue() => Random.Range(_minValue, _maxValue);
    }
}