using System;
using UnityEngine;

namespace Source.CodeBase.Infrastructure.Services.InputService
{
    public class MobileInput : IInputService
    {
        public event Action<Vector3> OnClicked;
        
        public void Tick()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended) 
                    OnClicked?.Invoke(touch.position);
            }
        }
    }
}