using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class WinSystem:IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<Timer> _timer;
        private RunGame _runGame;
        public void Run()
        {
            foreach (var VARIABLE in _timer)
            {
                if (_timer.Get1(VARIABLE).Time <= 0)
                {
                    _runGame.Win();
                }
            }
            
        }

        public void Init()
        {
            _runGame = Object.FindObjectOfType<RunGame>();
        }
    }
}