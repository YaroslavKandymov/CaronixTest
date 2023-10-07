using CaronixTest.EnemyComponents;
using CaronixTest.Factories;
using CaronixTest.Save;
using CaronixTest.ScriptableObjects;
using CaronixTest.Services;
using UnityEngine;
using Zenject;

namespace CaronixTest.Game
{
    public class GameInitializer : IInitializable
    {
        [Inject] private SaveDataMediator _saveDataMediator;
        [Inject] private EnemyService _enemyService;
        [Inject] private CanvasFactory _canvasFactory;
        [Inject] private CanvasesConfig _config;

        private EnterService _enterService;

        public void Initialize()
        {
            if (_saveDataMediator.PlayerName == null)
            {
                CreateEnterService();
            }
            else
            {
                _enemyService.StartWork();
            }
        }

        private void CreateEnterService()
        {
            _enterService = new EnterService(_canvasFactory, _config, _saveDataMediator);

            _enterService.Ended += OnEnterEnded;
        }

        private void OnEnterEnded()
        {
            _enterService.Ended -= OnEnterEnded;

            _enemyService.StartWork();
        }
    }
}