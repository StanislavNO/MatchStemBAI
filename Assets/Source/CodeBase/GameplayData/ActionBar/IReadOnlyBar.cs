using System;

namespace Source.CodeBase.GameplayData.ActionBar
{
    public interface IReadOnlyBar
    {
        event Action OnBarFulled;
    }
}