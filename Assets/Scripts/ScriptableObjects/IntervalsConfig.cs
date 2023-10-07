using System.Linq;
using CaronixTest.Enums;
using UnityEngine;

namespace CaronixTest.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new IntervalsConfig", menuName = "StaticData/IntervalsConfig", order = 3)]
    public class IntervalsConfig : ScriptableObject
    {
        [SerializeField] private IntervalData[] _datas;

        public int Get(ValueTypes type)
        {
            return _datas.FirstOrDefault(c => c.Type == type).GetRandomValue();
        }
    }
}