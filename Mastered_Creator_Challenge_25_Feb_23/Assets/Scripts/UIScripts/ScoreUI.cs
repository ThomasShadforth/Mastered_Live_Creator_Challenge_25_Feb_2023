using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreUI : MonoBehaviour, IObserver
{
    public PlayerBase playerBaseSubject;
    public EnemyBase AIBaseSubject;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;

    public GameObject gameEndUI;
    public TextMeshProUGUI gameEndText;

    // Start is called before the first frame update
    void Start()
    {
        if(playerBaseSubject != null)
        {
            playerBaseSubject.AddObserver(this);
        }

        if(AIBaseSubject != null)
        {
            AIBaseSubject.AddObserver(this);
        }

        playerScoreText.text = "Player: " + playerBaseSubject.baseScore;
        AIScoreText.text = "Enemy: " + AIBaseSubject.baseScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNotify(ScoreEnum scoreData)
    {
        playerScoreText.text = "Player: " + playerBaseSubject.baseScore;
        AIScoreText.text = "Enemy: " + AIBaseSubject.baseScore;

        if(playerBaseSubject.baseScore >= 5 || AIBaseSubject.baseScore >= 5)
        {
            playerBaseSubject.gameEnded = true;
            AIBaseSubject.gameEnded = true;
            DisplayGameEnd();
        }
    }

    public void DisplayGameEnd()
    {
        gameEndUI.SetActive(true);
        gameEndText.text = "The winner is: " + (playerBaseSubject.baseScore >= 5 ? "The Player" : "The Enemy") + "!";
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
