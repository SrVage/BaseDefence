using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class DestroyBomb:IEcsRunSystem
    {
        private EcsFilter<Bomb> _bomb;
        private EcsFilter<FallBomb> _fallBomb;
        public void Run()
        {
            foreach (var index in _bomb)
            {
                _bomb.Get1(index).DestroyTime -= Time.deltaTime;
                if (_bomb.Get1(index).DestroyTime<=0) _bomb.GetEntity(index).Destroy();
            }
            foreach (var index in _fallBomb)
            {
                _fallBomb.Get1(index).DestroyTime -= Time.deltaTime;
                if (_fallBomb.Get1(index).DestroyTime <= 0)
                {
                    GameObject.Destroy(_fallBomb.Get1(index).Position.gameObject);
                    _fallBomb.GetEntity(index).Destroy();
                }
            }
        }
    }
}