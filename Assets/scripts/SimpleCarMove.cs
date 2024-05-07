using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarMove : MonoBehaviour
{
    [SerializeField] private int speed = 20;
    private Vector3 startPos;
    [SerializeField] private string direction = "down";
    [SerializeField] private float downX = -48;
    [SerializeField] private float upX = 88;
    [SerializeField] private float downZ = -122;
    [SerializeField] private float upZ = 27.5f;

    private void Start() {
        startPos = transform.position;
    }

    void Update() {
        //transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (direction == "left" && transform.position.x < downX) {
            transform.position = startPos;
        }
        if (direction == "right" && transform.position.x > upX) {
            transform.position = startPos;
        }
        if (direction == "down" && transform.position.z < downZ) {
            transform.position = startPos;
        }
        if (direction == "up" && transform.position.z > upZ) {
            transform.position = startPos;
        }
    }
}
