using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUpDown : MonoBehaviour
{
    private int deltaY = 3;

    Vector3 point1;
    Vector3 point2;

    private void Start() {
        point1 = new Vector3(transform.position.x, transform.position.y + deltaY, transform.position.z);
        point2 = new Vector3(transform.position.x, transform.position.y - deltaY, transform.position.z);

    }

    void Update() {
        if (transform.position.y < point1.y)
            transform.position = Vector3.MoveTowards(transform.position, point1, Time.deltaTime*10);
        else if (transform.position.y > point2.y)
            transform.position = Vector3.MoveTowards(transform.position, point2, Time.deltaTime*10);
    }
}
