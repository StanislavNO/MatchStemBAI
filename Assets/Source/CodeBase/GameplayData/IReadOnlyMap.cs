using System;

namespace Source.CodeBase.GameplayData
{
    public interface IReadOnlyMap
    {
        event Action OnItemEnded;
    }
}