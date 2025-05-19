using System.Collections;
using UnityEngine;

namespace Source.CodeBase.GameplayData.Environment
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(Coroutine coroutine);
    }
}