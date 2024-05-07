using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertushka : MonoBehaviour
{
    public int rotationSpeed = 30;
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed);
    }
}
