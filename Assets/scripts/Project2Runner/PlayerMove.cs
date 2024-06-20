using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 20;
    //private int rotationSpeed = 80;
    private float horizontal;
    private float vertical;

    void Start() {

    }

    void Update() {
        // урок 1
        //transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);   // постоянное движение вперёд
        
        // урок 2
        //if (Input.GetKey(KeyCode.W)) {
        //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //}
        //if (Input.GetKey(KeyCode.S)) {
        //    transform.Translate(Vector3.back * Time.deltaTime * speed);
        //}
        
        // урок 3

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);   //для перемещения вправо-влево
        transform.Rotate(Vector3.up * Time.deltaTime * speed * horizontal);   //для поворотов вправо-влево
    }
}
