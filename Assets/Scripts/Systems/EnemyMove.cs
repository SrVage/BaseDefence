using System;
using Client.Components;
using Client.Services;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class EnemyMove:IEcsRunSystem
    {
        private Config _config;
        private EcsFilter<Health, Movable> enemy;
        public void Run()
        {
            foreach (var VARIABLE in enemy)
            {
                if (enemy.Get1(VARIABLE).IsAlive)
                {
                    enemy.Get2(VARIABLE).agent.enabled = true;  
                    enemy.Get2(VARIABLE).Position = enemy.Get2(VARIABLE).Transform.position;
                }
                else
                {
                    enemy.Get2(VARIABLE).agent.speed = 0;
                    enemy.Get2(VARIABLE).agent.enabled = false;
                }
            }
        }
    }
}