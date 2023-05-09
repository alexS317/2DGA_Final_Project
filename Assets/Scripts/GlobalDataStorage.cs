using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalDataStorage : MonoBehaviour
{
    public static GlobalDataStorage Instance;

    public int Score { get; private set; }
    public int playerLives = 3;

    private TMP_Text _livesDisplay;
    private TMP_Text _scoreDisplay;

    void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject); // Don't destroy the storage when changing scene
    }

    // Start is called before the first frame update
    void Start()
    {
        _livesDisplay = GameObject.Find("Lives").GetComponent<TMP_Text>();
        _scoreDisplay = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _livesDisplay.text = $"Lives: {playerLives}";
        _scoreDisplay.text = $"Score: {Score}";
    }

    // Increase the game score
    public void IncreaseScore(int points)
    {
        Score += points;
    }

    // Player loses one life on each attack
    public void AttackPlayer()
    {
        playerLives--;
    }
}