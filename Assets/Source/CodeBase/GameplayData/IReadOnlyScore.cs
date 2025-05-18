using System;

namespace Source.CodeBase.GameplayData
{
    public interface IReadOnlyScore
    {
        event Action OnScoreComplied;
        bool IsPlayerWin { get;}
    }
}