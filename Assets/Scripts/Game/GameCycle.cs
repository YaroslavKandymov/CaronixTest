using System;
using CaronixTest.EnemyComponents;
using CaronixTest.Services;
using UnityEngine;
using Zenject;

namespace CaronixTest.Game
{
    public class GameCycle : IInitializable, IDisposable
    {
        [Inject] private EnemyService _enemyService;
        [Inject] private FightService _fightService;
        [Inject] private ResultService _resultService;

        public void Initialize()
        {
            _enemyService.SearchFinished += OnEnemyServiceSearchFinished;
            _fightService.Ended += OnFightEnded;
            _resultService.Ended += OnResultEnded;
        }

        private void OnEnemyServiceSearchFinished()
        {
            var enemy = _enemyService.CreateEnemy();

            _fightService.Start(enemy);
        }

        private void OnFightEnded()
        {
            _resultService.StartWork();
        }

        private void OnResultEnded()
        {
            _enemyService.StartWork();
        }

        public void Dispose()
        {
            _enemyService.SearchFinished -= OnEnemyServiceSearchFinished;
            _fightService.Ended -= OnFightEnded;
        }
    }
}