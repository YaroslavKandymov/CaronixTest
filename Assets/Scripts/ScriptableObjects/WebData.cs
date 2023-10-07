using UnityEngine;

namespace CaronixTest.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new WebData", menuName = "StaticData/WebData", order = 1)]
    public class WebData : ScriptableObject
    {
        [SerializeField] private string _url;

        public string URL => _url;
    }
}