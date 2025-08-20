using UnityEngine;

public class CandySpawn : MonoBehaviour
{
    private Rigidbody2D rb;
    private float maxSpeed = 15f;
    private float minSpeed = 10f; // Added minSpeed for more control
    private float maxTorque = 5f;
    private float delay = 2f;
    private float spawnRate = 0.8f;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("SpawnCandy", delay, spawnRate);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SpawnCandy()
    {
        if (gameManager != null && gameManager.isActive == true)
        {
            if (gameManager.difficult == 1)
            {
                spawnRate = 1.5f;
            }
            else if (gameManager.difficult == 2)
            {
                spawnRate = 0.8f;
            }
            else if (gameManager.difficult == 3)
            {
                spawnRate = 0.3f;
            }
            int randomIndex = Random.Range(0, gameManager.gameObjects.Count);
            GameObject candyPrefab = gameManager.gameObjects[randomIndex];

            GameObject newCandy = Instantiate(candyPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = newCandy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(RandomForce(), ForceMode2D.Impulse);
                rb.AddTorque(RandomTorque(), ForceMode2D.Impulse);
            }
        }
    }
    void Update()
    {

    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}
