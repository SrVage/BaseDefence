using System;
using Client.Components;
using Client.Services;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Client
{
    public class CreateExplosion:IEcsRunSystem, IEcsInitSystem
    {
        private Config _config;
        private EcsFilter<FallBomb> _bomb;
        private EcsWorld _world = null;
        private EcsFilter<GetDamage, Movable> hasDamage;
        private EcsFilter<Bomb> _explosion;
        private SimpleCameraShakeInCinemachine _camera;
        public void Run()
        {
            if (!_explosion.IsEmpty()) return;
            foreach (var VARIABLE in _bomb)
            {
                if (_bomb.Get1(VARIABLE).DestroyTime <=0.1f)
                {
                    var bomb = _world.NewEntity();
                    var spawnedPrefab = GameObject.Instantiate(_config.Explosion
                        ,new Vector3(_bomb.Get1(VARIABLE).Position.position.x, 0, _bomb.Get1(VARIABLE).Position.position.z)
                        ,Quaternion.identity);
                    bomb.Get<Bomb>().DestroyTime = 0.1f;
                    _camera.Shake();
                    ref var position = ref bomb.Get<Bomb>().Position;
                     position = spawnedPrefab.transform;
                    foreach (var Enemy in hasDamage)
                    {
                        if ((hasDamage.Get2(Enemy).Position - spawnedPrefab.transform.position).magnitude <
                            _config.RadiusOfExplosion)
                        {
                            hasDamage.Get1(Enemy).HasDamage = true;
                        }
                    }
                }
            }
        }

        public void Init()
        {
            _camera = Object.FindObjectOfType<SimpleCameraShakeInCinemachine>();
        }
    }
}