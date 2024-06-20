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
            }

        }

    }

    private void FixedUpdate() {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 SpeedVector = inputVector * speed;

        Vector3 speedVectorRelativeTotPlayer = transform.TransformVector(SpeedVector);  // переводим вектор в локальую систему координат игрока
        rb.velocity = new Vector3(speedVectorRelativeTotPlayer.x, rb.velocity.y, speedVectorRelativeTotPlayer.z);
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
}
