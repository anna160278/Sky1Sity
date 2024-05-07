using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    // 1 - модификатор доступа, 2 - тип данных, 3 - имя переменной/идентификатор

    // модификаторы доступа: public и private

    public int apples;
    private float speed = 15.45f;
    private GameObject panel;

    // самые часто используемые типы данных:
    // int
    // float
    // string
    // bool

    //public int health = 15;       // целое число 

    //private int maxHealth = 100;
    //private int number = 5;
    //private float number2 = 5.5f; // 1.2f, 2.5, 
    //private string text = "Hello world";
    //private char letter = 'D';
    //private bool isBool = true;

    //private GameObject player;
    //private Transform player1;

    // Правиля именования переменных:
    // 1) имя должно отвечать на вопрос, для чего она нужна
    // 2) с маленькой буквы
    // 3) если 2 слова использовать camelCase
    // 4) не начинать с цифр и не использовать _ в качестве разделителя слов

    void Start() {
        if (SceneManager.GetActiveScene().name == "RoadsCity") {
            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            panel = canvas.transform.Find("Panel").gameObject;
            Debug.Log(panel.name);
        }

    }


    void Update() {

    }
}