using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GunController : MonoBehaviour
{
   
    private float horizontalInput;
    private float verticalInput;
    private float sensitivity = 50f;
    public float verticalRange = 30f;
    public float horizontalRange = 90f;
    private Quaternion gunRotation;
    private float verticalAngle = 0f;  // Начальный угол
    private float horizontalAngle = 0f;


    public enum ControlTypes { keyboard, mouse }

    public ControlTypes inputControl = ControlTypes.keyboard;

    void Update() {

        if (inputControl == ControlTypes.keyboard) {
            //Управление клавишами
            horizontalInput = Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime;
            verticalInput = Input.GetAxis("Vertical") * sensitivity * Time.deltaTime;
        }
        else {
            // Получаем движение мыши
            horizontalInput = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            verticalInput = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        }

        //transform.Rotate(0, horizontalInput, 0);   // мышь + простое управление урок1
        //transform.Rotate(0, 0, verticalInput);

        // Улучшенное управление. Добавляем движение к текущему углу
        verticalAngle -= verticalInput;
        verticalAngle = Mathf.Clamp(verticalAngle, -verticalRange, verticalRange); // Ограничение углов в пределах диапазона

        horizontalAngle += horizontalInput;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -horizontalRange, horizontalRange); // Ограничение углов в пределах диапазона

        // Вращение ружья
        // Горизонт (Y)
        gunRotation = Quaternion.Euler(0f, horizontalAngle, 0f);
        // Вертикал (Х) с ограничениями
        gunRotation = Quaternion.Euler(verticalAngle, gunRotation.eulerAngles.y, 0f);

        // Применяем вращение - это указатель на объект ружья
        transform.localRotation = gunRotation;
    }
}