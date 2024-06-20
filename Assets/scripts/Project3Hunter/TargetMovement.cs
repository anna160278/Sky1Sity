using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float speed;
    public float xRange = 121;

    private void Start() {
        speed = Random.Range(5, 20);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds() {
        if(transform.position.x > xRange || transform.position.x < -xRange) {
            Destroy(gameObject);
        }
    }
}
