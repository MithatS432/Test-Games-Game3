using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Difficuilty : MonoBehaviour
{
    public int difficult = 1;
    public GameObject canvas;
    public GameObject ScoreUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Easy()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.isActive = true;
            gameManager.difficult = 1; // Set difficulty to Easy
            canvas.SetActive(false); // Hide the difficulty selection UI
            ScoreUI.gameObject.SetActive(true);
        }
    }
    public void Medium()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.isActive = true;
            gameManager.difficult++; // Set difficulty to Medium
            canvas.SetActive(false); // Hide the difficulty selection UI
            ScoreUI.gameObject.SetActive(true);
        }
    }
    public void Hard()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.isActive = true;
            gameManager.difficult += 2; // Set difficulty to Hard
            canvas.SetActive(false); // Hide the difficulty selection UI
            ScoreUI.gameObject.SetActive(true);
        }
    }
}
