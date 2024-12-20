using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager4 : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI textCoins;
    public GameObject startScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public PlayerController4 player;
    public int lifes;
    public TextMeshProUGUI textLifes;
    public SoundManager4 soundManager;


    void Start() {
        coins = 0;
        lifes = 3;
        UpdateText();
        Time.timeScale = 0f;
        startScreen.gameObject.SetActive(true);
    }

    public void Update() {
        if (lifes <= 0) {
            StartCoroutine(Lose(2));
        }
    }

    public void UpdateText() {
        if (textCoins != null) {
            textCoins.text = "coins: " + coins.ToString();
        }
        if (textLifes != null) {
            textLifes.text = "lifes: " + lifes.ToString();
        }
    }

    public void ResetPlayer() {
        startScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        player.ResetToStartPosition();
        Time.timeScale = 1f;
    }

    public void RestartGame() {
        startScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // перезапускает текущий уровень
    }

    public void GameOver() {
        loseScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        soundManager.PlayDieSound();
    }

    public void WinGame() {
        winScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    IEnumerator Lose(float delay) {
        player.speed = 0;
        player.animator.SetTrigger("death");
        yield return new WaitForSeconds(delay);
        GameOver();
    }
}
