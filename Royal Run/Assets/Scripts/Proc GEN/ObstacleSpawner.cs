using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform obstacleParent;

    [Header("Obstacle Spawner Settings")]
    [SerializeField] float obstacleSpawnTime = 1f;
    [SerializeField] float minObstacleSpawnTime = .2f;
    [SerializeField] float spawnWidth = 4f;

    void Start()
    {

        StartCoroutine(SpawnObstacleRoutine());

    }
    public void DecreaseObsticleSpawnTime(float amount)
    {
        obstacleSpawnTime -= amount;

        if (obstacleSpawnTime <= minObstacleSpawnTime)
        {
            obstacleSpawnTime = minObstacleSpawnTime;
        }
    }
    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);


            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation,obstacleParent);
            
        }
    
    }

}
