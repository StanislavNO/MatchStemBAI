using Source.CodeBase.Logic.Controllers;

namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public class StartState : GameState
    {
        private readonly Spawner _spawner;

        public StartState(IStateSwitcher switcher, Spawner spawner) : base(switcher)
        {
            _spawner = spawner;
        }

        public override void Enter()
        {
            base.Enter();

            _spawner.Run();
            Switch();
        }

        protected override void Subscribe()
        {
        }

        protected override void Unsubscribe()
        {
        }

        protected override void Switch() =>
            Switcher.SwitchState<GameLoopState>();
    }
}