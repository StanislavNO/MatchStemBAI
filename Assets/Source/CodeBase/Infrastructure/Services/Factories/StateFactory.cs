using System.Collections.Generic;
using Source.CodeBase.Logic.GlobalFSM;

namespace Source.CodeBase.Infrastructure.Services.Factories
{
    public class StateFactory
    {
        private IStateSwitcher _switcher;

        public StateFactory()
        {
            
        }
        
        public void Init(IStateSwitcher stateSwitcher)
        {
            _switcher = stateSwitcher;
        }

        public List<IState> Create()
        {
            return null;
        }
    }
}