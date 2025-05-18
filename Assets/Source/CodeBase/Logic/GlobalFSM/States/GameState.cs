namespace Source.CodeBase.Logic.GlobalFSM.States
{
    public abstract class GameState : IState
    {
        protected IStateSwitcher Switcher { get; private set; }

        protected GameState(IStateSwitcher switcher)
        {
            Switcher = switcher;
        }
        
        public virtual void Enter() => Subscribe();

        public virtual void Exit() => Unsubscribe();

        protected abstract void Subscribe();

        protected abstract void Unsubscribe();

        protected abstract void Switch();
    }
}