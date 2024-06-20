using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    public float speed;
    private float horizontal;
    private float height = 0.5f;
    private float low = 0.5f;
    private float minSize = 0.5f;
    private float maxSize = 7f;
    private float jumpForce = 15f;
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isStoped = false;
    public Animator animator;
    public GameManager2 gameManager;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (!isStoped) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
        }
        gameManager.UpdateLifeUI();
    }


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("GrowUp")) {
            Debug.Log("GrowUp");
            Destroy(other.gameObject);
            transform.localScale += new Vector3(height, height, height);

            if (transform.localScale.y > maxSize) {     // чтобы игрок не становился слишком большим
                transform.localScale = Vector3.one * maxSize;
            }
        }

        if (other.CompareTag("GrowDown")) {
            Debug.Log("GrowDown");
            Destroy(other.gameObject);
            transform.localScale -= new Vector3(low, low, low);

            if (transform.localScale.y < minSize) {     // чтобы игрок не становился слишком маленьким
                transform.localScale = Vector3.one * minSize;
            }
        }

        if (other.CompareTag("Coin")) {
            gameManager.score++;
            Destroy(other.gameObject);
            Debug.Log("Coins: " + gameManager.score);
        }

        if (other.CompareTag("Health") && gameManager.lifes < gameManager.maxHealth) {
            gameManager.lifes++;
            Destroy(other.gameObject);
            Debug.Log("lifes: " + gameManager.lifes);
            gameManager.UpdateLifeUI();
        }
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.collider.tag == "Ground") {
            Debug.Log("Коснулись пола");
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }

        if (collision.collider.tag == "Obstacle") {
            gameManager.lifes--;
            gameManager.UpdateLifeUI();
            if (gameManager.lifes <= 0) {
                animator.SetTrigger("die");
                gameManager.GameOver();
            }
        }

        if (collision.collider.tag == "Door") {
            Debug.Log("Коснулись door");
            isStoped = true;
            animator.SetTrigger("stop");
            gameManager.winPanel.gameObject.SetActive(true);
        }
    }
}

