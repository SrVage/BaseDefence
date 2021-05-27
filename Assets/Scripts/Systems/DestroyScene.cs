using System;
using Client.Components;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class DestroyScene:IEcsDestroySystem
    {
        private EcsFilter<Movable> _enemy;
        private EcsFilter<Bomb> _bomb;
        private EcsFilter<Timer> _timer;
        private EcsFilter<FallBomb> _fallBomb;
        public void Destroy()
        {
            foreach (var VARIABLE in _enemy)
            {
                GameObject.Destroy(_enemy.Get1(VARIABLE).Transform.gameObject);
                _enemy.GetEntity(VARIABLE).Destroy();
            }
            foreach (var VARIABLE in _bomb)
            {
                _bomb.GetEntity(VARIABLE).Destroy();
            }
            foreach (var VARIABLE in _fallBomb)
            {
                GameObject.Destroy(_fallBomb.Get1(VARIABLE).Position.gameObject);
                _fallBomb.GetEntity(VARIABLE).Destroy();
            }
        }
    }
}