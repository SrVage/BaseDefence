using Client.Components;
using Client.Services;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class InputSystem:IEcsRunSystem, IEcsInitSystem
    {
        private Config _config;
        EcsWorld _world = null;
        private Camera _camera;
        private float _wait=0;

        public void Run()
        {
            _wait -= Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && _wait<=0)
            {
                RaycastHit hit;
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    SpawnBomb(hit.point);
                }
            }
        }

        private void SpawnBomb(Vector3 spawn)
        {
            var bomb = _world.NewEntity();
            var spawnedBomb = GameObject.Instantiate(_config.Bomb,
                spawn+new Vector3(0,5,0), Quaternion.identity);
            ref var position = ref bomb.Get<FallBomb>().Position;
            bomb.Get<FallBomb>().DestroyTime = 1.2f;
                position = spawnedBomb.transform;
                _wait = 1;
        }

        public void Init()
        {
            _camera = Object.FindObjectOfType<Camera>();
            
        }
    }
}