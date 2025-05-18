using Source.CodeBase.GameplayData;
using Source.CodeBase.Logic.Controllers;

namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public class GameLoopState : GameState
    {
        private readonly PlayerInputController _playerInputController;
        private readonly ViewController _viewController;
        private readonly IReadOnlyScore _score;
        private readonly IReadOnlyMap _map;
        
        public GameLoopState(
            IStateSwitcher switcher, 
            PlayerInputController playerInputController,
            ViewController viewController,
            IReadOnlyMap mapData,
            IReadOnlyScore score) : base(switcher)
        {
            _playerInputController = playerInputController;
            _viewController = viewController;
            _score = score;
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
            _score.OnScoreComplied += Switch;
            _map.OnItemEnded += Switch;
        }

        protected override void Unsubscribe()
        {
            _viewController.OnRestartClicked -= OnRestartClicked;
            _score.OnScoreComplied -= Switch;
            _map.OnItemEnded -= Switch;
        }

        protected override void Switch() =>
            Switcher.SwitchState<GameOverState>();
        
        private void OnRestartClicked() =>
            Switcher.SwitchState<RestartState>();
    }
}