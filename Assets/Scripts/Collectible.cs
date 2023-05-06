using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int points = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GlobalDataStorage.Instance.IncreaseScore(points);   // Increase the player's total score
        Destroy(this.gameObject);   // Destroy the object when it has been collected
    }
}
