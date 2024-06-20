using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager2 : MonoBehaviour
{
    [SerializeField] PlayerRunner playerRunner;
    [SerializeField] float levelRestartDelay = 1f; // время перезагрузки в секундах
    [SerializeField] Text timeText;
    [SerializeField] Text scoreText;
    public Camera mainCamera;
    public Camera deathCamera;
    public int lifes = 3;
    public int maxHealth = 5;
    public GameObject winPanel;
    public Image[] hearts;
    public Sprite LifeOn, LifeOff;

    [HideInInspector]
    public int score = 0;
    public int time = 0;
    private float increaseSpeed = .2f;

    void Start() {
        mainCamera.gameObject.SetActive(true);
        deathCamera.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
        UpdateLifeUI();
        StartCoroutine(timer(1.0f));
    }

    public void GameOver() {
        mainCamera.gameObject.SetActive(false);
        deathCamera.gameObject.SetActive(true);
        playerRunner.enabled = false; // отключаем движение игрока
        Debug.Log("Game over");
        UpdateLifeUI();
        Invoke("RestartLevel", levelRestartDelay); // вызываем метод рестарт через опред. время
    }

    public void RestartLevel() {
        StartCoroutine(timer(1.0f));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // перезапускает текущий уровень
    }

    public void UpdateLifeUI() {
        for (int i = 0; i < hearts.Length; i++) {
            if (lifes > i) {
                hearts[i].sprite = LifeOn;
            }
            else {
                hearts[i].sprite = LifeOff;
            }
        }
    }

    // таймер счета
    IEnumerator timer(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            playerRunner.speed += increaseSpeed;
            if (playerRunner.enabled == false || winPanel.gameObject.active == true) {
                scoreText.text = "SCORE: " + score.ToString();
                timeText.text = "TIME: " + time.ToString(); }
            else {
                time++;
                scoreText.text = "SCORE: " + score.ToString();
                timeText.text = "SPEED: " + playerRunner.speed.ToString("F1"); } // float.ToString("F1") - чтобы выводилось число с 1 цифрой после запятой
        }
    }
}