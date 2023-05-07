using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : MonoBehaviour
{
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
        Debug.Log("You won!");
        Debug.Log("Total points: " + GlobalDataStorage.Instance.Score);
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.EndScreen);
    }
}
