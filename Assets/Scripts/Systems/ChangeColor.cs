using Components;
using Leopotam.Ecs;

namespace Client
{
    public class ChangeColor:IEcsRunSystem
    {
        private EcsFilter<Health, Color> color;
        public void Run()
        {
            foreach (var VARIABLE in color)
            {
                if (color.Get1(VARIABLE).HP>0)
                    color.Get2(VARIABLE).MeshRenderer.material.color = UnityEngine.Color.Lerp(UnityEngine.Color.white, UnityEngine.Color.red, 1 - color.Get1(VARIABLE).HP/50);
                else color.Get2(VARIABLE).MeshRenderer.material.color = UnityEngine.Color.blue;
            }
        }
    }
}