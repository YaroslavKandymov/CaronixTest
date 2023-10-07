using System;
using CaronixTest.Enums;
using CaronixTest.Factories;
using CaronixTest.ScriptableObjects;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CaronixTest.EnemyComponents
{
    public class EnemyService
    {
        [Inject] private WebData _webData;
        [Inject] private EnemyFactory _enemyFactory;
        [Inject] private IntervalsConfig _intervalsConfig;
        
        public EnemyData Data { get; private set; }

        public event Action Started;
        public event Action SearchFinished;

        public void StartWork()
        {
            Started?.Invoke();
        }

        public async UniTask<EnemyData> GetNewData()
        {
            var dataLoader = new DataLoader();
            Data = await dataLoader.GetData(_webData.URL);

            return Data;
        }

        public void FinishSearch()
        {
            SearchFinished?.Invoke();
        }

        public Enemy CreateEnemy()
        {
            var enemy = _enemyFactory.Create();
            
            enemy.Init(_intervalsConfig.Get(ValueTypes.Health));

            return enemy;
        }
    }
}