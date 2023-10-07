using CaronixTest.EnemyComponents;
using UnityEngine;

namespace CaronixTest.Factories
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _template;

        public Enemy Create()
        {
            return Instantiate(_template);
        }
    }
}