using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class UITime:IEcsRunSystem,IEcsInitSystem
    {
        private Text _timeUI;
        private Text _enemyTime;
        private EcsFilter<Timer> _timer;
        private EcsFilter<EnemyTimer> _enemyTimer;
        public void Run()
        {
            foreach (var VARIABLE in _timer)
            {
                _timeUI.text = ((int)_timer.Get1(VARIABLE).Time).ToString();
            }
            foreach (var VARIABLE in _enemyTimer)
            {
                _enemyTime.text = ((int)_enemyTimer.Get1(VARIABLE)._timer).ToString();
            }
        }

        public void Init()
        {
            _timeUI = Object.FindObjectOfType<UnityText>().gameObject.GetComponent<Text>();
            _enemyTime = Object.FindObjectOfType<UnityEnemyTime>().gameObject.GetComponent<Text>();
        }
    }
}