using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewPlayerContoller : MonoBehaviour
{
    [SerializeField] private int horsePower = 20;       // движение будет организовано через физику
    private Rigidbody playerRb;
    [SerializeField] private float speed;               // скорость открываем, чтобы отображать значение скорости, высчитанное в зависимости от силы
    [SerializeField] TextMeshProUGUI textSpeedometr;
    [SerializeField] private float rpm;
    [SerializeField] TextMeshProUGUI textRpm;
    [SerializeField] private int rotationSpeed = 15;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private float verticalInput;
    private float horizontalInput;



    [SerializeField] GameObject centerOfMass;

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.centerOfMass = centerOfMass.transform.position;
    }
    void FixedUpdate() {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (IsOnGround()) {
            //Move the vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);     // вариант кода, через физику в локальном пространстве
            //Turning the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);     // Нужно не передвигать, а поворачивать вокруг вертикальной оси
            //print speed
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);  // 3.6 for km/h, 2.237 for mph
            textSpeedometr.SetText("Speed: " + speed + "km/h");
            //print RPM
            rpm = Mathf.Round((speed % 30) * 40);   // не совсем корректное решение, приближённое
            textRpm.SetText("RPM: " + rpm);

        }
    }

    bool IsOnGround() {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels) {
            if (wheel.isGrounded) {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4) {
            return true;
        }
        else {
            return false;
        }
    }
}
