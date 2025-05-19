using Source.CodeBase.GameplayData;
using Source.CodeBase.GameplayData.ActionBar;
using Source.CodeBase.Logic.Controllers;

namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public class GameOverState : GameState
    {
        private readonly ViewController _viewController;
        private readonly IReadOnlyMap _map;

        public GameOverState(
            IStateSwitcher switcher,
            ViewController viewController,
            IReadOnlyMap map) : base(switcher)
        {
            _viewController = viewController;
            _map = map;
        }

        public override void Enter()
        {
            base.Enter();

            if (_map.IsItemsEnded)
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