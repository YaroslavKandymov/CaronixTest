using CaronixTest.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace CaronixTest.Installers
{
    [CreateAssetMenu(fileName = "new StaticDataInstaller", menuName = "StaticData/StaticDataInstaller", order = 0)]
    public class StaticDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private WebData _webData;
        [SerializeField] private CanvasesConfig _canvasesConfig;
        [SerializeField] private IntervalsConfig _intervalsConfig;
        
        public override void InstallBindings()
        {
            BindWebData();
            BindCanvasData();
            BindIntervalsConfig();
        }

        private void BindWebData()
        {
            Container.BindInstance(_webData);
        }

        private void BindCanvasData()
        {
            Container.BindInstance(_canvasesConfig);
        }

        private void BindIntervalsConfig()
        {
            Container.BindInstance(_intervalsConfig);
        }
    }
}