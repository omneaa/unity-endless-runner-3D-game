
using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject blackCoinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject staticObstaclePrefab;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnStaticObstacle();  // Call this function to spawn static obstacles at the start
        StartCoroutine(SpawnBlackCoin());
    }

    IEnumerator SpawnBlackCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            GameObject temp = Instantiate(blackCoinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(0, 4);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnStaticObstacle()
    {

        float randomX = Random.Range(-4f, 4f);

        // Fixed y position
        float y = 0f;

        // Choose a random z position greater than 3 and after the first 9 units within the collider's bounds
        float minZ = Mathf.Max(GetComponent<Collider>().bounds.min.z, 10f);
        float maxZ = GetComponent<Collider>().bounds.max.z;
        float randomZ = Random.Range(minZ, maxZ);

        // Create the position vector
        Vector3 spawnPosition = new Vector3(randomX, y, randomZ);

        // Instantiate the static obstacle at the position
        Instantiate(staticObstaclePrefab, spawnPosition, Quaternion.identity, transform);

    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}





/*using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject blackCoinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject staticObstaclePrefab;

    private void Start()
    {
        StartCoroutine(SpawnBlackCoin());
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    IEnumerator SpawnBlackCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);

            // Randomize x position between -2 and 5
            float randomX = Random.Range(-2f, 5f);

            // Set y position to 0
            float y = 1f;

            // Calculate z position based on the current position plus 6 units
            float z = transform.position.z + 6f;

            // Instantiate the black coin at the calculated position
            GameObject temp = Instantiate(blackCoinPrefab, new Vector3(randomX, y, z), Quaternion.identity);

            // Set the parent to the current GroundTile
            temp.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnStaticObstacle()
    {
        int obstacleSpawnIndex = Random.Range(0, 2);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(staticObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
*/