using CaronixTest.EnemyComponents;
using CaronixTest.Factories;
using CaronixTest.Game;
using CaronixTest.Save;
using CaronixTest.Services;
using CaronixTest.UI;
using UnityEngine;
using Zenject;

namespace CaronixTest.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        
        public override void InstallBindings()
        {
            BindSaveDataMediator();
            BindCanvasFactory();
            BindEnemyFactory();
            BindEnemyService();
            BindEnemyPresenter();
            BindGameInitializer();
            BindFightService();
            BindResultServiceService();
            BindFightAdapter();
            BindResultAdapter();
            BindGameCycle();
        }

        private void BindSaveDataMediator()
        {
            Container
                .Bind<SaveDataMediator>()
                .AsSingle();
        }

        private void BindCanvasFactory()
        {
            Container
                .Bind<CanvasFactory>()
                .AsSingle();
        }

        private void BindGameInitializer()
        {
            Container
                .BindInterfacesAndSelfTo<GameInitializer>()
                .AsSingle();
        }

        private void BindEnemyService()
        {
            Container
                .Bind<EnemyService>()
                .AsSingle();
        }

        private void BindEnemyPresenter()
        {
            Container
                .BindInterfacesAndSelfTo<SearchWindowPresenter>()
                .AsSingle();
        }

        private void BindResultServiceService()
        {
            Container
                .BindInterfacesAndSelfTo<ResultService>()
                .AsSingle();
        }

        private void BindFightService()
        {
            Container
                .BindInterfacesAndSelfTo<FightService>()
                .AsSingle();
        }

        private void BindFightAdapter()
        {
            Container
                .BindInterfacesAndSelfTo<FightWindowAdapter>()
                .AsSingle();
        }

        private void BindResultAdapter()
        {
            Container
                .BindInterfacesAndSelfTo<ResultWindowPresenter>()
                .AsSingle();
        }

        private void BindEnemyFactory()
        {
            Container.BindInstance(_enemyFactory);
        }

        private void BindGameCycle()
        {
            Container
                .BindInterfacesAndSelfTo<GameCycle>()
                .AsSingle();
        }
    }
}