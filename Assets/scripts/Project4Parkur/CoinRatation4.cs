using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRatation4 : MonoBehaviour
{
    private float rotationSpeed = 100;
    

    void Update()
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
}
