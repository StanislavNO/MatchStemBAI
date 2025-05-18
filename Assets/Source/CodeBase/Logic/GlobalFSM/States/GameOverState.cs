using Source.CodeBase.GameplayData;
using Source.CodeBase.Logic.Controllers;

namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public class GameOverState : GameState
    {
        private readonly ViewController _viewController;
        private readonly IReadOnlyScore _score;

        public GameOverState(
            IStateSwitcher switcher,
            ViewController viewController,
            IReadOnlyScore score) : base(switcher)
        {
            _viewController = viewController;
            _score = score;
        }

        public override void Enter()
        {
            base.Enter();

            if (_score.IsPlayerWin)
                _viewController.ShowWinScreen();
            else
                _viewController.ShowLoseScreen();
        }

        protected override void Subscribe()
        {
            _viewController.OnNextClicked += Switch;
        }

        protected override void Unsubscribe()
        {
            _viewController.OnNextClicked -= Switch;
        }

        protected override void Switch() =>
            Switcher.SwitchState<RestartState>();
    }
}