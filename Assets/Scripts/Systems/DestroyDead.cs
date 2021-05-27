using Client.Components;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class DestroyDead:IEcsRunSystem
    {
        private EcsFilter<TimeOfDead, Movable> dead;
        public void Run()
        {
            foreach (var VARIABLE in dead)
            {
                dead.Get1(VARIABLE).DeadTime -= Time.deltaTime;
                if (dead.Get1(VARIABLE).DeadTime <= 0)
                {
                    GameObject.Destroy(dead.Get2(VARIABLE).Transform.gameObject);
                    dead.GetEntity(VARIABLE).Destroy();
                }
            }
        }
    }
}