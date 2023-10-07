using System;
using System.Linq;
using CaronixTest.Enums;
using UnityEngine;

namespace CaronixTest.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new CanvasesConfig", menuName = "StaticData/CanvasesConfig", order = 2)]
    public class CanvasesConfig : ScriptableObject
    {
        [SerializeField] private CanvasData[] _datas;

        public Canvas Get(CanvasesTypes type)
        {
            return _datas.FirstOrDefault(c => c.Type == type)?.Prefab;
        }
    }

    [Serializable]
    public class CanvasData
    {
        [SerializeField] private CanvasesTypes _type;
        [SerializeField] private Canvas _prefab;

        public CanvasesTypes Type => _type;
        public Canvas Prefab => _prefab;
    }
}