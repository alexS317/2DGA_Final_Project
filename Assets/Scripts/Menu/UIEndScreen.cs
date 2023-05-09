using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEndScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    
    private TMP_Text _endMessage;
    private TMP_Text _totalScore;
    
    // Start is called before the first frame update
    void Start()
    {
        _endMessage = GameObject.Find("EndMessage").GetComponent<TMP_Text>();
        _totalScore = GameObject.Find("Score").GetComponent<TMP_Text>();

        // Display end message depending on whether player lost or won
        if (GlobalDataStorage.Instance.playerLives <= 0)
        {
            _endMessage.text = "You lost! Go for another try!";
        }
        else
        {
            _endMessage.text = "Congratulations, you won!";
            _totalScore.text = $"Total score: {GlobalDataStorage.Instance.Score}";
        }
        
        restartButton.onClick.AddListener(ScenesManager.Instance.LoadGame);
        menuButton.onClick.AddListener(ScenesManager.Instance.LoadMainMenu);
    }
}
