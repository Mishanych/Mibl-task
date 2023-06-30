using Factory;
using UnityEngine;

namespace BombManagement
{
    public class BombSpawnFactory : RandomSpawnFactory<Bomb>
    {
        private const string DefaultBombName = "Bomb";

        public override GameObject Spawn(Bomb bomb, Vector3 planeCenter)
        {
            GameObject bombObject = bomb.gameObject;

            bombObject = Object.Instantiate(bombObject,
                GetRandomPositionOnPlane(planeCenter, bomb.SpawnSettings.SpawnedRadius), Quaternion.identity);

            bombObject.name = DefaultBombName;

            return bombObject;
        }
    }
}