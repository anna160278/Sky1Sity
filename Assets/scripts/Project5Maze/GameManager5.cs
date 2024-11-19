using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager5 : MonoBehaviour
{
    public float HP = 100f;
    public float maxHP = 100f;
    public GameObject winPanel;
    public GameObject losePanel;

    void Start() {
        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    void Update() {
        if (HP <= 0) {
            GameOver();
        }
    }

    public void GameOver() {
        losePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinGame() {
        winPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1;
    }
}
