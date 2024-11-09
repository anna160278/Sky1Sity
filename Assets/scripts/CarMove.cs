using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private int speed = 20;            // В Unity атрибут [SerializeField] используется для того, 
    [SerializeField] private int rotationSpeed = 15;    // чтобы сделать private переменные доступными в испекторе Unity, не делая их общедоступными.
    private float verticalInput;
    private float horizontalInput;

    void Update() {
        //transform.position = transform.position + new Vector3(0, 0, 1) * Time.deltaTime * 20;  // 1) сначала пишем так, машина начинает двигаться

        //transform.Translate(Vector3.forward * Time.deltaTime * speed);         // 2) улучшенный код, в инспекторе можно менять скорость (даже ставить с минусом)

        //if (Input.GetKey(KeyCode.W)) {
        //    transform.Translate(Vector3.forward * Time.deltaTime * speed);     // 3) вариант кода, где проверяется нажатие конкретных клавиш 
        //}
        //if (Input.GetKey(KeyCode.S)) {
        //    transform.Translate(Vector3.back * Time.deltaTime * speed);
        //}
        //if (Input.GetKey(KeyCode.A)) {
        //    transform.Translate(Vector3.left * Time.deltaTime * speed);
        //}
        //if (Input.GetKey(KeyCode.D)) {
        //    transform.Translate(Vector3.right * Time.deltaTime * speed);
        //}

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);     // 4) вариант кода, движение через GetAxis
        horizontalInput = Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);     // такой вариант для движения вправо-влево для машины не подходит. 
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);     // Нужно не передвигать, а поворачивать вокруг вертикальной оси

    }
}
