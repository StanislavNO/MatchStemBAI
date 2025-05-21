using Source.CodeBase.Configs;
using Source.CodeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private LevelSetting _levelSetting;

        public override void InstallBindings()
        {
            BindConfigs();
            BindInput();
        }

        private void BindInput()
        {
            Container.BindInterfacesTo<MobileInput>().AsSingle();
        }

        private void BindConfigs()
        {
            Container.BindInstance(_levelSetting).AsSingle();
        }
    }
}