using Factory;
using UnityEngine;

namespace BombManagement
{
    public class BombSpawnFactory<T> : RandomSpawnFactory<T> where T : Bomb
    {
        private const string DefaultBombName = "Bomb";

        public override GameObject Spawn(T bomb)
        {
            GameObject bombObject = bomb.gameObject;

            bombObject = Object.Instantiate(bombObject, GetRandomPositionOnPlane(Vector3.zero, 5f), Quaternion.identity);
            bombObject.name = DefaultBombName;

            return bombObject;
        }
    }
}