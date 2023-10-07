using UnityEngine;
using Zenject;

namespace CaronixTest.Factories
{
    public class CanvasFactory
    {
        private readonly DiContainer _container;
        
        public CanvasFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create(Canvas canvas)
        {
            return _container.InstantiatePrefab(canvas);
        }
    }
}