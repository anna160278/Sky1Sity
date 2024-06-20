using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawn;

    void Update() {
        Quaternion bulletRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet, spawn.position, bulletRotation);
        }
    }
}
