using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    void Awake()
    {
        // Don't create a scenes manager if there already is one
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject); // Don't destroy it when the scene changes
    }

    public enum Scene
    {
        MainMenu,
        Level01,
        EndScreen
    }

    // Load any scene
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    // Load the game starting from the first level
    public void LoadGame()
    {
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    // Load the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}