using System;

namespace Source.CodeBase.GameplayData
{
    public class ActionBarData : IReadOnlyScore
    {
        public event Action OnScoreComplied;
        
        public bool IsPlayerWin { get; private set; }
    }
}