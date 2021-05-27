using Client.Components;
using Client.Services;
using Components;
using Leopotam.Ecs;

namespace Client
{
    public class Damage:IEcsRunSystem
    {
        private EcsFilter<Health, Movable, GetDamage> health;
        private EcsFilter<Bomb> bomb;
        private Config _config;
        public void Run()
        {
            foreach (var index in health)
            {
                if (!health.Get3(index).HasDamage) continue;
                foreach (var VAR in bomb)
                {
                    if (bomb.Get1(VAR).Position == null) continue;
                    if ((health.Get2(index).Position - bomb.Get1(VAR).Position.position).magnitude < _config.RadiusOfExplosion)
                    {
                        health.Get1(index).HP -=
                            _config.StrenghtOfExplosion*(110 - (health.Get2(index).Position - bomb.Get1(VAR).Position.position).magnitude * 10);
                        if (health.Get1(index).HP < 0) health.Get1(index).HP = 0;
                        if (health.Get1(index).HP == 0) health.Get1(index).IsAlive = false;
                        health.Get3(index).HasDamage = false;
                    }
                }
            }
        }
    }
}