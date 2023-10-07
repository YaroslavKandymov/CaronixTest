using System;
using CaronixTest.EnemyComponents;
using CaronixTest.Enums;
using CaronixTest.Factories;
using CaronixTest.ScriptableObjects;
using CaronixTest.Services;
using Zenject;

namespace CaronixTest.UI
{
    public class FightWindowAdapter : IInitializable, IDisposable
    {
        [Inject] private CanvasesConfig _config;
        [Inject] private CanvasFactory _factory;
        [Inject] private FightService _fightService;
        [Inject] private EnemyService _enemyService;

        private FightWindow _fightWindow;
        
        public void Initialize()
        {
            var canvas = _factory.Create(_config.Get(CanvasesTypes.Fight));

            _fightWindow = canvas.GetComponentInChildren<FightWindow>();

            _fightWindow.Restart();
            _fightWindow.Close();
            
            _fightService.Started += OnStarted;
            _fightService.Ended += OnEnded;
            _fightService.EnemyHealthChanged += OnEnemyHealthChanged;
        }

        private void OnStarted()
        {
            _fightWindow.Init(_enemyService.Data.Name);
            _fightWindow.Restart();
            _fightWindow.Open();
        }

        private void OnEnemyHealthChanged(int currentValue, int maxValue)
        {
            _fightWindow.ChangeValue(currentValue, maxValue);
        }

        private void OnEnded()
        {
            _fightWindow.Close();
            _fightWindow.Restart();
        }

        public void Dispose()
        {
            _fightService.Ended -= OnEnded;
            _fightService.EnemyHealthChanged -= OnEnemyHealthChanged;
        }
    }
}