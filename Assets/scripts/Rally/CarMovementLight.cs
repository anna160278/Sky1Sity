using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovementLight : MonoBehaviour // Объявление класса CarMovement, наследующего MonoBehaviour
{
    public float speed; // Публичное поле для скорости машины
    public float maxSpeed; // Максимальная скорость вперед
    private float rotationSpeed = 100f; // Публичное поле для скорости вращения машины

    [HideInInspector]
    public float acceleration = 20f; // Значение ускорения для быстрого старта
    public float deceleration = 10f; // Значение замедления для быстрой остановки
    public float maxReverseSpeed = -20f; // Максимальная скорость назад
    //public float brakeSpeed = 20f; // Торможение до полной остановки

    private Vector3 startPosition;

    // step2 - check circle
    public GameManager manager;


    public Text textField;

    private void Start() {
        startPosition = transform.position;
    }

    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W)) {
            // Ускоряемся и ограничиваем скорость максимальным значением
            speed = Mathf.MoveTowards(speed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) {
            // Если мы двигались вперед и нажали S, то начинаем интенсивное торможение
            speed = Mathf.MoveTowards(speed, maxReverseSpeed, acceleration * Time.deltaTime);
        }
        else {
            // Плавное замедление при отпускании клавиш
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape) || OutOfBounds()) {
            ResetToStartPosition();
        }

        // Обычное управление
        transform.Rotate(Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
        // Перемещение и вращение
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        // Обновляем текстовое поле со скоростью
        textField.text = "SPEED: " + Mathf.Abs((int)speed);

    }

    void OnTriggerEnter(Collider other) // Не забудь добавить Collider с галочкой isTrigger
    {
        if (other.CompareTag("Block")) // Предполагаем, что у машины тег "Player"
        {
            Debug.Log("Block");
            manager.CheckpointReached(other.gameObject);
        }

        if (other.CompareTag("Finish")) {
            Debug.Log("Finish");
            manager.FinishLineReached(other.gameObject);
        }
    }

    bool OutOfBounds() {
        if (transform.position.y <-2 || transform.position.y >50)
            return true;
        else 
            return false;
    }
    public void ResetToStartPosition() {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        speed = 0;
    }
}