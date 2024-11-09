using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 50.0f;
    private GameManager3 gameManager;

    private void Start() {
        gameManager = GameObject.Find("GameManager3").GetComponent<GameManager3>();
    }
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z >= 200) {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Animal")) {
            Debug.Log("попали в цель");
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.score++;
            Debug.Log("score: " + gameManager.score);
        }
    }

}
