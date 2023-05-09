using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.EndScreen);
    }
}
