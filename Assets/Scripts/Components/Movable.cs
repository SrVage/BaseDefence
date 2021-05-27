using UnityEngine;
using UnityEngine.AI;

namespace Client.Components
{
    public struct Movable
    {
        public Vector3 EnemyTarget;
        public Vector3 Position;
        public Transform Transform;
        public NavMeshAgent agent;
    }
}