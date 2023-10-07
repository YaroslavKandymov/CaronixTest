using CaronixTest.EnemyComponents;
using CaronixTest.Enums;
using CaronixTest.Factories;
using CaronixTest.ScriptableObjects;
using CaronixTest.Services;
using Zenject;

namespace CaronixTest.UI
{
    public class ResultWindowPresenter : IInitializable
    {
        [Inject] private CanvasesConfig _config;
        [Inject] private CanvasFactory _factory;
        [Inject] private ResultService _resultService;
        [Inject] private EnemyService _enemyService;

        private ResultWindow _resultWindow;
        
        public void Initialize()
        {
            var canvas = _factory.Create(_config.Get(CanvasesTypes.Finish));

            _resultWindow = canvas.GetComponentInChildren<ResultWindow>();
            
            _resultWindow.Close();

            _resultService.Started += OnStarted;
            _resultWindow.ContinueClicked += OnContinueClicked;
        }

        private void OnStarted()
        {
            _resultWindow.Fill(_enemyService.Data.Name, _resultService.GetReward().ToString());
            _resultWindow.Open();
        }

        private void OnContinueClicked()
        {
            _resultWindow.Close();
            _resultService.End();
        }
    }
}