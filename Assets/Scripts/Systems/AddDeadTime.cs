using Components;
using Leopotam.Ecs;

namespace Client
{
    public class AddDeadTime:IEcsRunSystem
    {
        private EcsFilter<Health>.Exclude<TimeOfDead> addDead;
        public void Run()
        {
            foreach (var VARIABLE in addDead)
            {
                if (!addDead.Get1(VARIABLE).IsAlive)
                    addDead.GetEntity(VARIABLE).Get<TimeOfDead>().DeadTime=5;
            }
        }
    }
}