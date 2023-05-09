using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(ScenesManager.Instance.LoadGame);
        exitButton.onClick.AddListener(Application.Quit);
    }
}
