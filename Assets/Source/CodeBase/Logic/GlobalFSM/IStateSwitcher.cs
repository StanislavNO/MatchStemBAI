namespace Source.CodeBase.Logic.GlobalFSM
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}