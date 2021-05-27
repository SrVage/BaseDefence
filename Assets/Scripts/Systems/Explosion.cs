using Client.Components;
using Client.Services;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class Explosion:IEcsRunSystem
    {
        private EcsFilter<Movable, Physic, GetDamage> enemy;
        private EcsFilter<Bomb> bomb;
        private Config _config;
        public void Run()
        {
            foreach (var VARIABLE in enemy)
            {
                if (!enemy.Get3(VARIABLE).HasDamage) continue;
                foreach (var VAR in bomb)
                {
                    if ((enemy.Get1(VARIABLE).Position - bomb.Get1(VAR).Position.position).magnitude < _config.RadiusOfExplosion)
                    {
                        enemy.Get2(VARIABLE).Rigidbody.isKinematic = false;
                        var force = _config.RadiusOfExplosion - (enemy.Get1(VARIABLE).Position - bomb.Get1(VAR).Position.position).magnitude*_config.StrenghtOfExplosion;
                        var direction = (enemy.Get1(VARIABLE).Position-bomb.Get1(VAR).Position.position).normalized;
                        enemy.Get2(VARIABLE).Rigidbody.AddForce(force*direction/1, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}