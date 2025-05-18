using Source.CodeBase.Logic.Controllers;

namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public class RestartState : GameState
    {
        private readonly RestartController _restartController;
        
        public RestartState(
            IStateSwitcher switcher, 
            RestartController restartController) : base(switcher)
        {
            _restartController = restartController;
        }

        public override void Enter()
        {
            base.Enter();

            _restartController.RebuildLevel();
        }

        protected override void Subscribe()
        {
        }

        protected override void Unsubscribe()
        {
        }

        protected override void Switch() =>
            Switcher.SwitchState<StartState>();
    }
}