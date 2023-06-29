using UnityEngine;

namespace Factory
{
    public abstract class RandomSpawnFactory<T> where T : class
    {
        public abstract GameObject Spawn(T objectToSpawn);

        protected Vector3 GetRandomPositionOnPlane(Vector3 planeCenter, float spawnRadius)
        {
            // Generate a random point within a circle on the XY plane
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;

            // Calculate the random position on the plane
            Vector3 randomPosition = new Vector3(randomPoint.x, planeCenter.y, randomPoint.y);

            return randomPosition;
        }
    }
}