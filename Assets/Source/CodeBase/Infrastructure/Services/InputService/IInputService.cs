using System;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Services.InputService
{
    public interface IInputService : ITickable
    {
        event Action<Vector3> OnClicked;
    }
}