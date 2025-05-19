using System;
using Source.CodeBase.GameplayData.ActionBar;

namespace Source.CodeBase.GameplayData
{
    public class ActionBarData : IReadOnlyBar
    {
        public event Action OnBarFulled;
    }
}