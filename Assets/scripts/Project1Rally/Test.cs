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
    private bool isBool = true;

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
    //private GameObject panel;
    //private Transform player1;

    // Правиля именования переменных:
    // 1) имя должно отвечать на вопрос, для чего она нужна
    // 2) с маленькой буквы
    // 3) если 2 слова использовать camelCase
    // 4) не начинать с цифр и не использовать _ в качестве разделителя слов

    void Start() {
        Debug.Log("Привет из метода Start()");
        Debug.Log("Начальная скорость машины равна = " + speed);
        if (isBool == true) {
            apples = 10;
            Debug.Log("У вас в корзине было " + apples + " яблок");
        }
    }

    void Update() {
        Debug.Log("Привет из метода Update()");
        if (Input.GetKeyDown(KeyCode.Space)) {
            apples++;
            Debug.Log("Теперь у вас " + apples + " яблок");
        }
    }
}