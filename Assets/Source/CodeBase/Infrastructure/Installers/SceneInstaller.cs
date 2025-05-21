using System;
using Source.CodeBase.GameplayData;
using Source.CodeBase.GameplayData.ActionBar;
using Source.CodeBase.GameplayData.Environment;
using Source.CodeBase.Infrastructure.Services.Factories;
using Source.CodeBase.Logic.Controllers;
using Source.CodeBase.Logic.GlobalFSM;
using Source.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private ViewActionBar _viewActionBar;
        [SerializeField] private SpawnPoint _spawnPoint;
        [SerializeField] private UIParticleMover _uiParticleMover;

        public override void InstallBindings()
        {
            BindDatas();
            BindEnvironment();
            BindFactories();
            BindControllers();
            BindView();
            BindGameStateMachine();
        }

        private void BindGameStateMachine()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<GameStateMachine>().AsSingle().NonLazy();
        }

        private void BindEnvironment()
        {
            Container
                .BindInterfacesAndSelfTo<SpawnPoint>()
                .FromInstance(_spawnPoint)
                .AsSingle();
            
            Container.BindInstance(_uiParticleMover).AsSingle();
        }

        private void BindDatas()
        {
            Container.BindInterfacesAndSelfTo<ActionBarData>().AsSingle();
            Container.BindInterfacesAndSelfTo<MapData>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<ItemFactory>().AsSingle();
        }

        private void BindView()
        {
            Container.BindInstance(_viewActionBar).AsSingle();
        }

        private void BindControllers()
        {
            Container.BindInterfacesAndSelfTo<Spawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartController>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ViewController>().AsSingle();
        }
    }
}