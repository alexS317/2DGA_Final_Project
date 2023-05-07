using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GlobalDataStorage : MonoBehaviour
{
    public static GlobalDataStorage Instance;

    public int Score { get; private set; }
    public int playerLives = 3;

    private TMP_Text _livesObj;
    private TMP_Text _scoreObj;

    void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _livesObj = GameObject.Find("Lives").GetComponent<TMP_Text>();
        _scoreObj = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _livesObj.text = $"Lives: {playerLives}";
        _scoreObj.text = $"Score: {Score}";
    }

    // Increase the game score
    public void IncreaseScore(int points)
    {
        Score += points;
        Debug.Log(Score);
    }

    // Player loses one life on each attack
    public void AttackPlayer()
    {
        playerLives--;
        Debug.Log(playerLives);
    }
}