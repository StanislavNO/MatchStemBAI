using System;
using System.Collections.Generic;
using System.Linq;
using Source.CodeBase.Infrastructure.Services.Factories;
using Source.CodeBase.Logic.GlobalFSM.States;
using Zenject;

namespace Source.CodeBase.Logic.GlobalFSM
{
    public class GameStateMachine : IStateSwitcher, IInitializable, IDisposable
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public GameStateMachine(StateFactory factory)
        {
            factory.Init(this);
            _states = factory.Create();
        }

        public void Initialize() => SwitchState<StartState>();

        public void Dispose() => _currentState?.Exit();

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}