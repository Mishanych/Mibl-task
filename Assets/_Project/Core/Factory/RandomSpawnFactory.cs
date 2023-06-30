using UnityEngine;

namespace Factory
{
    public abstract class RandomSpawnFactory<T> where T : MonoBehaviour
    {
        public abstract GameObject Spawn(T objectToSpawn, Vector3 planeCenter);

        protected Vector3 GetRandomPositionOnPlane(Vector3 planeCenter, float spawnedRadius)
        {
            // Generate a random point within a circle on the 2D plane
            Vector2 randomPoint = Random.insideUnitCircle * spawnedRadius;

            // Calculate the random position on the plane
            Vector3 randomPosition = new Vector3(randomPoint.x, planeCenter.y, randomPoint.y);

            return randomPosition;
        }
    }
}