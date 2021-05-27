using System;
using Client.Components;
using Components;
using Leopotam.Ecs;
using Object = UnityEngine.Object;

namespace Client
{
    public class LooseSystem:IEcsInitSystem, IEcsRunSystem
    {
        private RunGame _runGame;
        private EcsFilter<Health, Movable> _enemy;
        public void Init()
        {
            _runGame = Object.FindObjectOfType<RunGame>();
        }

        public void Run()
        {
            foreach (var VARIABLE in _enemy)
            {
                if (_enemy.Get1(VARIABLE).IsAlive && _enemy.Get2(VARIABLE).Position.z<-5) _runGame.Loose();
            }
        }
    }
}