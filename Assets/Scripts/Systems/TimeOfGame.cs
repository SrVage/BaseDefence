using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class TimeOfGame:IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world = null;
        private EcsEntity time;
        public void Run()
        {
            time.Get<Timer>().Time -= Time.deltaTime;
        }

        public void Init()
        {
            time = _world.NewEntity();
            time.Get<Timer>().Time = 25f;
        }
    }
}