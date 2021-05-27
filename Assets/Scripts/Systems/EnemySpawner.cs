using Client.Components;
using Client.Services;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;
using Color = Components.Color;

namespace Client
{
    internal class EnemySpawner : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world = null;
        private Config _config;
        private EcsEntity _waitTime;

        public void Init()
        {
            _waitTime = _world.NewEntity();
            _waitTime.Get<EnemyTimer>()._timer = _config.EnemyConfig.WaitTime;
            EnemySpawn();
        }

        private void EnemySpawn()
        {
             for (int i = 0; i < 5; i++)
             {
                 var enemy = _world.NewEntity();
                 ref var position =  ref enemy.Get<Movable>().Transform;
                 ref var agent = ref enemy.Get<Movable>().agent;
                 ref var physic = ref enemy.Get<Physic>().Rigidbody;
                 ref var hp = ref enemy.Get<Health>().HP;
                 hp = 100;
                 ref var hasDamage = ref enemy.Get<GetDamage>().HasDamage;
                 hasDamage = false;
                 ref var meshRenderer = ref enemy.Get<Color>().MeshRenderer;
                 enemy.Get<Health>().IsAlive = true;
                 enemy.Get<Movable>().EnemyTarget = _config.EnemyConfig.TargetPosition[Random.Range(0, 5)];
                 var spawnedPrefab = GameObject.Instantiate(_config.EnemyConfig.Prefab,
                     _config.EnemyConfig.SpawnPosition[i], Quaternion.identity);
                 position = spawnedPrefab.transform;
                 agent = spawnedPrefab.GetComponent<NavMeshAgent>();
                 physic = spawnedPrefab.GetComponent<Rigidbody>();
                 meshRenderer = spawnedPrefab.GetComponent<MeshRenderer>();
                 spawnedPrefab.GetComponent<NavMeshAgent>().destination =
                     enemy.Get<Movable>().EnemyTarget;
                 spawnedPrefab.GetComponent<NavMeshAgent>().speed = _config.EnemyConfig.Speed;
                 
             }
        }

        public void Run()
        {
            _waitTime.Get<EnemyTimer>()._timer -= Time.deltaTime;
            if (_waitTime.Get<EnemyTimer>()._timer <= 0)
            {
                EnemySpawn();
                _waitTime.Get<EnemyTimer>()._timer = _config.EnemyConfig.WaitTime;
            }
        }
        
    }
}