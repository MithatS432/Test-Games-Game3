using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TextScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public TextMeshProUGUI healthText;

    private int score = 0;
    public static TextScore Instance;
    public static int health = 3;
    public Button restartButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
        UpdateHealthText();
        restartButton.gameObject.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        UpdateHealthText();

        if (health == 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().GameOver();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
            healthText.text = "Health Left: " + health.ToString();
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
