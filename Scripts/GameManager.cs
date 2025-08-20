using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public bool isActive;
    public int difficult = 1;
    public int point;
    void Start()
    {

    }

    void Update()
    {

    }
    public void GameOver()
    {
        isActive = false;
    }
}
