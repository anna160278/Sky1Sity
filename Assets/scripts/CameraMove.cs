using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Vector3 offset;    // В Unity атрибут [SerializeField] используется для того, 
                                                // чтобы сделать private переменные доступными в испекторе Unity, не делая их общедоступными.
    public GameObject player;


    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;    
        transform.rotation = player.transform.rotation;
    }
}
