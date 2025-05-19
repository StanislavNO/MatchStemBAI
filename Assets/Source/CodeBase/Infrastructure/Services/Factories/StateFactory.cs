using System.Collections.Generic;
using Source.CodeBase.GameplayData;
using Source.CodeBase.GameplayData.ActionBar;
using Source.CodeBase.Logic.Controllers;
using Source.CodeBase.Logic.GlobalFSM;
using Source.CodeBase.Logic.GlobalFSM.States;

namespace Source.CodeBase.Infrastructure.Services.Factories
{
    public class StateFactory
    {
        private readonly Spawner _spawner;
        private readonly PlayerInputController _playerInputController;
        private readonly ViewController _viewController;
        private readonly IReadOnlyBar _bar;
        private readonly IReadOnlyMap _map;

        private IStateSwitcher _switcher;

        public StateFactory(
            Spawner spawner,
            PlayerInputController playerInputController,
            ViewController viewController,
            IReadOnlyBar bar,
            IReadOnlyMap map)
        {
            _spawner = spawner;
            _playerInputController = playerInputController;
            _viewController = viewController;
            _bar = bar;
            _map = map;
        }

        public void Init(IStateSwitcher stateSwitcher) =>
            _switcher = stateSwitcher;

        public List<IState> Create()
        {
            List<IState> states = new()
            {
                new StartState(_switcher, _spawner),
                new GameLoopState(_switcher, _playerInputController, _viewController, _map, _bar)
            };

            return states;
        }
    }
}