using System;
using CaronixTest.EnemyComponents;
using CaronixTest.Enums;
using CaronixTest.Factories;
using CaronixTest.Save;
using CaronixTest.ScriptableObjects;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CaronixTest.UI
{
    public class SearchWindowPresenter : IInitializable, IDisposable
    {
        [Inject] private CanvasesConfig _config;
        [Inject] private CanvasFactory _factory;
        [Inject] private EnemyService _enemyService;
        [Inject] private SaveDataMediator _saveDataMediator;

        private EnemyWindow _enemyWindow;
        private LoadingWindow _loadingWindow;

        public void Initialize()
        {
            var canvas = _factory.Create(_config.Get(CanvasesTypes.Search));

            _enemyWindow = canvas.GetComponentInChildren<EnemyWindow>();
            _loadingWindow = canvas.GetComponentInChildren<LoadingWindow>();
            
            _enemyWindow.Close();
            _loadingWindow.Close();
            
            _enemyWindow.SearchClicked += OnSearchClicked;
            _enemyWindow.FightClicked += OnFightClicked;
            
            _enemyService.Started += OnStarted;
        }

        public void Dispose()
        {
            _enemyWindow.SearchClicked -= OnSearchClicked;
            _enemyWindow.FightClicked -= OnFightClicked;

            _enemyService.Started -= OnStarted;
        }

        private void OnStarted()
        {
            _enemyWindow.InitPlayerName(_saveDataMediator.PlayerName, _saveDataMediator.Money);
            Search().Forget();
        }

        private void OnSearchClicked()
        {
            Search().Forget();
        }

        private void OnFightClicked()
        {
            _enemyWindow.Close();
            _loadingWindow.Close();
            
            _enemyService.FinishSearch();
        }

        private async UniTask Search()
        {
            _enemyWindow.Close();
            _loadingWindow.Open();
            
            var data = await _enemyService.GetNewData();
            
            _loadingWindow.Close();
            _enemyWindow.Open();
            
            _enemyWindow.ShowEnemy(data.Name, data.Avatar);
        }
    }
}