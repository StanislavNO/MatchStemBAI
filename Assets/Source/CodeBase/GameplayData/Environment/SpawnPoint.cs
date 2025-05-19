using UnityEngine;

namespace Source.CodeBase.GameplayData.Environment
{
    public class SpawnPoint : MonoBehaviour, ICoroutineRunner
    {
        public Vector3 Position => transform.position;
    }
}