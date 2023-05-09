using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleComponent : MonoBehaviour
{
    [SerializeField] private int points = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GlobalDataStorage.Instance.IncreaseScore(points);   // Increase the player's total score
        Destroy(this.gameObject);   // Destroy the object when it has been collected
    }
}
