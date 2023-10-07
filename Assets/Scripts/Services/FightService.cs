using System;
using CaronixTest.EnemyComponents;
using CaronixTest.Enums;
using CaronixTest.ScriptableObjects;
using Zenject;
using Object = UnityEngine.Object;

namespace CaronixTest.Services
{
    public class FightService : IDisposable
    {
        [Inject] private IntervalsConfig _intervalsConfig;
        
        private Enemy _enemy;
        private int _startHealth;
        
        public event Action Started;
        public event Action Ended;
        public event Action<int, int> EnemyHealthChanged; 

        public void Start(Enemy enemy)
        {
            _enemy = enemy;
            _startHealth = _enemy.Health;
            
            Started?.Invoke();

            _enemy.ClickMechanic.Clicked += OnClicked;
            _enemy.HealthChanged += OnHealthChanged;
        }

        public void Dispose()
        {
            _enemy.ClickMechanic.Clicked -= OnClicked;
            _enemy.HealthChanged -= OnHealthChanged;
        }

        private void OnClicked()
        {
            _enemy.Hit(_intervalsConfig.Get(ValueTypes.Damage));
        }

        private void OnHealthChanged()
        {
            EnemyHealthChanged?.Invoke(_enemy.Health, _startHealth);
            
            if (_enemy.Health <= 0)
            {
                Object.Destroy(_enemy.gameObject);
                
                Ended?.Invoke();
            }
        }
    }
}