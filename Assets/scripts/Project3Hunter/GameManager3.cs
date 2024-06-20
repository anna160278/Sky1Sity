using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    public int score = 0;
    public Text textScore;
    public GameObject winScreen;
    public int scoreToWin = 10;

    void Start() {
        winScreen.gameObject.SetActive(false);
        score = 0;
        
    }


    void Update() {
        UpdateUI();
        if (score >= scoreToWin) {
            Time.timeScale = 0f;
            OnWinScreen();
        }
    }

    void UpdateUI() {
        textScore.text = "score: " + score;
    }

    void OnWinScreen() {
        winScreen.gameObject.SetActive(true);
    }

    public void RestartGame() {

        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
