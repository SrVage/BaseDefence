using Client.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;
        public Config Config;
        void Start () {
            // void can be switched to IEnumerator for support coroutines.
           
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new Damage())
                .Add (new EnemySpawner())
                .Add ( new EnemyMove())
                .Add(new InputSystem())
                .Add(new ChangeColor())
                .Add(new AddDeadTime())
                .Add(new DestroyDead())
                .Add(new DestroyBomb())
                .Add(new TimeOfGame())
                .Add(new UITime())
                .Add(new DestroyScene())
                .Add(new WinSystem())
                .Add(new LooseSystem())
                .Add(new CreateExplosion())
                .Add(new Explosion())
                

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                .Inject (Config)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}