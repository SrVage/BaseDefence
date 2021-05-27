using UnityEngine;

namespace Client.Services
{
    [CreateAssetMenu]
    public class Config:ScriptableObject
    {
        public EnemyConfig EnemyConfig;
        public GameObject Explosion;
        public GameObject Bomb;
        public int StrenghtOfExplosion;
        public int RadiusOfExplosion;
    }
}