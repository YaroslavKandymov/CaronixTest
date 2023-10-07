using System;
using CaronixTest.Enums;
using CaronixTest.Factories;
using CaronixTest.Save;
using CaronixTest.ScriptableObjects;
using CaronixTest.UI;
using UnityEngine;
using Zenject;

namespace CaronixTest.Services
{
    public class EnterService
    {
        private readonly CanvasFactory _canvasFactory;
        private readonly CanvasesConfig _config;
        private readonly SaveDataMediator _saveDataMediator;
        private readonly EnterWindow _enterWindow;

        public event Action Ended;
        
        public EnterService(CanvasFactory canvasFactory, CanvasesConfig config, SaveDataMediator mediator)
        {
            _canvasFactory = canvasFactory;
            _config = config;
            _saveDataMediator = mediator;
            
            var canvas = _canvasFactory.Create(_config.Get(CanvasesTypes.Meet));

            _enterWindow = canvas.GetComponentInChildren<EnterWindow>();
            _enterWindow.Open();
            
            _enterWindow.ContinueClicked += OnContinued;
        }

        private void OnContinued()
        {
            _enterWindow.ContinueClicked -= OnContinued;
            
            _saveDataMediator.SaveName(_enterWindow.Value);
            
            Ended?.Invoke();
        }
    }
}