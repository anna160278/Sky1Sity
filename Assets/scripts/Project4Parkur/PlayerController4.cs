using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public int speed = 10;
    private float rotationSpeed = 50;
    public int jumpforce = 100;
    private Rigidbody rb;
    private bool isGrounded = true;
    public GameManager4 gameManager;
    private Vector3 startPosition;
    public Animator animator;
    void Start() {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.name);
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }


    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);

        if (vertical != 0) {
            //animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            animator.SetBool("isJumping", true);
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        if (OutOfBounds()) {
            gameManager.lifes--;
            gameManager.UpdateText();
            ResetToStartPosition();
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Island")) {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            gameManager.lifes--;
            gameManager.UpdateText();
            Destroy(collision.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            gameManager.coins++;
            gameManager.UpdateText();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Health")) {
            gameManager.lifes++;
            gameManager.UpdateText();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish")) {
            gameManager.WinGame();
        }
    }

    bool OutOfBounds() {
        if (transform.position.y < 50)
            return true;
        else
            return false;
    }
    public void ResetToStartPosition() {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }
}

