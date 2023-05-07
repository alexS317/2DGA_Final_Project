using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GlobalDataStorage : MonoBehaviour
{
    public static GlobalDataStorage Instance;

    private int _score;
    public int playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Increase the game score
    public void IncreaseScore(int points)
    {
        _score += points;
        Debug.Log(_score);
    }

    // Player loses one life on each attack
    public void AttackPlayer()
    {
        playerLives--;
        Debug.Log(playerLives);
    }
}