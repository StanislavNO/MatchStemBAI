using System;

namespace Source.CodeBase.GameplayData
{
    public class MapData : IReadOnlyMap
    {
        public event Action OnItemEnded;
    }
}