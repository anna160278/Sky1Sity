using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player5Controller : MonoBehaviour
{
    //[SerializeField] int speed = 20;
    //[SerializeField] int rotationSpeed = 100;


    //void Update() {
    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");
    //    float mouseHorizontal = Input.GetAxis("Mouse X");

    //    transform.Translate(Vector3.forward * speed * vertical * Time.deltaTime);
    //    transform.Rotate(Vector3.up * rotationSpeed * horizontal * Time.deltaTime);
    //    transform.Rotate(Vector3.up * rotationSpeed * mouseHorizontal * Time.deltaTime);
    //}

    public float rotationSensitivity;
    public Transform cameraTransform;
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    private float xRotation;
    private bool grounded;
    public GameManager5 gameManager;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        // Задаём вращение камеры вверх-вниз и игрока вместе с камерой вправо-влево

        if (Input.GetMouseButton(1)) {
            xRotation -= Input.GetAxis("Mouse Y") * rotationSensitivity;
            xRotation = Mathf.Clamp(xRotation, -60, 60); // Функция Clamp ограничивает указанный параметр в заданных пределах
                                                         // (если нужно обрезает либо в меньшую, либо в большую сторону)

            cameraTransform.localEulerAngles = new Vector3(xRotation, 0, 0);   //задаём вращение камеры вокруг оси Х, если пользователь
                                                                               //зажал левую кнопку мыши и двигает ею вверх-вниз

            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSensitivity, 0); //задаём вращение игрока вокруг оси Y, если пользователь
                                                                                    //зажал левую кнопку мыши и двигает ею вправо-влево
        }

        // делаем прыжок

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded)  // разрешаем прыжок, только если игрок стоит на земле
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                animator.SetTrigger("jump");
            }
        }
    }

    private void FixedUpdate() {    // Метод FixedUpdate() вызывается каждый фиксированный кадр, что делает его подходящим для работы с физикой.
                                    // Он вызывается с постоянным интервалом времени, что позволяет более точно управлять физическими расчетами.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputVector = new Vector3(horizontal, 0f, vertical);    //Создает вектор inputVector, который представляет направление
                                                                        //движения на основе значений horizontal и vertical.
                                                                        //Ось Y равна 0, так как движение происходит только по плоскости XZ.
        Vector3 SpeedVector = inputVector * speed;      // Умножает inputVector на переменную speed, создавая вектор скорости SpeedVector,
                                                        // который определяет скорость движения персонажа.
        Vector3 speedVectorRelativeTotPlayer = transform.TransformVector(SpeedVector);  // Преобразует SpeedVector из мировой системы координат
        // в локальную систему координат объекта (персонажа).Это позволяет учитывать ориентацию персонажа при движении.
        rb.velocity = new Vector3(speedVectorRelativeTotPlayer.x, rb.velocity.y, speedVectorRelativeTotPlayer.z); 
        // Устанавливает скорость Rigidbody (rb) персонажа.
        // При этом сохраняется текущая скорость по оси Y (например, для учета гравитации),
        // а скорости по осям X и Z обновляются на основе рассчитанного локального вектора скорости.
        
        if (horizontal == 0 && vertical == 0) {
            animator.SetBool("isRunning", false);
        }
        else {
            animator.SetBool("isRunning", true);
        }
    }


    private void OnCollisionStay(Collision collision) {
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(normal, Vector3.up);    // Функция Dot возвращает 1, если векторы направлены в 1 сторону,
                                                        // -1, если векторы противоположны, 0, если векторы перпендикулярны
        if (dot > 0.5f) {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        grounded = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("DamageDoor")) {
            gameManager.HP -= 25;
        }
        if (other.gameObject.CompareTag("DeathDoor")) {
            gameManager.HP = 0;
        }
        if (other.gameObject.CompareTag("Finish")) {
            gameManager.WinGame();
        }
    }
}
