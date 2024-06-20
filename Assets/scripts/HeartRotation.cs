using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotation : MonoBehaviour
{
    private float rotationSpeed = 100;

    void Update() {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
