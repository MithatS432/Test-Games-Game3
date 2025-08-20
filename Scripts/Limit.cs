using UnityEngine;

public class Limit : MonoBehaviour
{
    private int minObjects = -5;
    private int maxObjects = 5;
    public ParticleSystem particleSystem;
    public AudioClip candySound;

    void Start()
    {
        transform.position = RandomPosition();
    }

    void OnMouseDown()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(candySound, transform.position);
        if (CompareTag("Candy"))
        {
            TextScore.Instance.AddScore(20);
        }
        else
        {
            TextScore.Instance.ReduceHealth(1);
            TextScore.Instance.AddScore(-15);
            if (TextScore.health == 0)
            {
                TextScore.Instance.GameOver();
            }
        }
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(minObjects, maxObjects);
        return new Vector3(x, -6.97f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }
}
