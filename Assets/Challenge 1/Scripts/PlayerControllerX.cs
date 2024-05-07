using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;


    void Start() {

    }

    void FixedUpdate() {
        // Получаем пользовательскую вертикальную ось
        verticalInput = Input.GetAxis("Vertical");

        // Двигаем самолёт вперёд
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Получаем пользовательскую горизонтальную ось
        horizontalInput = Input.GetAxis("Horizontal");

        // Крутим самолёт вверх/вниз, нажимая на соответствующие клавиши
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
