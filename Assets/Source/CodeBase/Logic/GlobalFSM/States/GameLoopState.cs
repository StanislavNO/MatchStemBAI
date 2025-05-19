using Source.CodeBase.GameplayData;
using Source.CodeBase.GameplayData.ActionBar;
using Source.CodeBase.Logic.Controllers;

namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public class GameLoopState : GameState
    {
        private readonly PlayerInputController _playerInputController;
        private readonly ViewController _viewController;
        private readonly IReadOnlyBar _bar;
        private readonly IReadOnlyMap _map;
        
        public GameLoopState(
            IStateSwitcher switcher, 
            PlayerInputController playerInputController,
            ViewController viewController,
            IReadOnlyMap mapData,
            IReadOnlyBar bar) : base(switcher)
        {
            _playerInputController = playerInputController;
            _viewController = viewController;
            _bar = bar;
            _map = mapData;
        }

        public override void Enter()
        {
            base.Enter();

            _playerInputController.IsEnable = true;
        }

        public override void Exit()
        {
            base.Exit();

            _playerInputController.IsEnable = false;
        }

        protected override void Subscribe()
        {
            _viewController.OnRestartClicked += OnRestartClicked;
            _bar.OnBarFulled += Switch;
            _map.OnItemEnded += Switch;
        }

        protected override void Unsubscribe()
        {
            _viewController.OnRestartClicked -= OnRestartClicked;
            _bar.OnBarFulled -= Switch;
            _map.OnItemEnded -= Switch;
        }

        protected override void Switch() =>
            Switcher.SwitchState<GameOverState>();
        
        private void OnRestartClicked() =>
            Switcher.SwitchState<RestartState>();
    }
}