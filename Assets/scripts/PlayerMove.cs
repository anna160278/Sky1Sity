using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 20;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
    }
}
