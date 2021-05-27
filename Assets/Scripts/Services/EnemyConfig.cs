using UnityEngine;

namespace Client.Services
{
    [CreateAssetMenu]
    public class EnemyConfig:ScriptableObject
    {
        public GameObject Prefab;
        public float Speed = 2.0f;
        public Vector3[] SpawnPosition;
        public Vector3[] TargetPosition;
        public float WaitTime = 5;
    }
}