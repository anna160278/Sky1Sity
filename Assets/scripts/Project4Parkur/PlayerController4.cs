using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public int speed = 10;
    //private float rotationSpeed = 50;
    public int jumpforce = 100;
    private Rigidbody rb;
    private bool isGrounded = true;
    public GameManager4 gameManager;
    private Vector3 startPosition;
    public Animator animator;

    public float rotationSensitivity = 5;
    public Transform cameraTransform;
    private float xRotation;

    public SoundManager4 soundManager;

    public GameObject collectCoinEffect;
    public GameObject healingEffect;
    public GameObject damageEffect;
    public GameObject waterDamageEffect;

    public List<GameObject> checkPoints;

    void Start() {
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.name);
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        collectCoinEffect.SetActive(false);
        healingEffect.SetActive(false);
        damageEffect.SetActive(false);
        waterDamageEffect.SetActive(false);
    }


    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal* speed * Time.deltaTime);
        //transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);

        // Задаём вращение камеры вверх-вниз и игрока вместе с камерой вправо-влево

        if (Input.GetMouseButton(1)) {
            xRotation -= Input.GetAxis("Mouse Y") * rotationSensitivity;
            xRotation = Mathf.Clamp(xRotation, -60, 60); // Функция Clamp ограничивает указанный параметр в заданных пределах
                                                         // (если нужно обрезает либо в меньшую, либо в большую сторону)
            cameraTransform.localEulerAngles = new Vector3(xRotation, 0, 0);   //задаём вращение камеры вокруг оси Х, если пользователь
                                                                               //зажал левую кнопку мыши и двигает ею вверх-вниз
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSensitivity, 0); //задаём вращение игрока вокруг оси Y, если пользователь
                                                                                    //зажал левую кнопку мыши и двигает ею вправо-влево
        }

        if (vertical == 0 && horizontal == 0) {
            animator.SetBool("isRunning", false);
        }
        else {
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            animator.SetTrigger("jump");
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Island")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            EnableDamageEffect();
            gameManager.lifes--;
            gameManager.UpdateText();
            Destroy(collision.gameObject);
            Invoke("ResetToStartPosition", 1);
            Invoke("DisableDamageEffect", 1);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Вы столкнулись с " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Coin")) {
            EnableCoinEffect();
            gameManager.coins++;
            gameManager.UpdateText();
            Destroy(other.gameObject);
            Invoke("DisableCoinEffect", 1);
        }
        if (other.gameObject.CompareTag("Health")) {
            EnableHealingEffect();
            gameManager.lifes++;
            gameManager.UpdateText();
            Destroy(other.gameObject);
            Invoke("DisableHealingEffect", 1);
        }
        if (other.gameObject.CompareTag("Water")) {
            EnableWaterDamageEffect();
            gameManager.lifes--;
            gameManager.UpdateText();
            Invoke("ResetToStartPosition", 1);
            Invoke("DisableWaterDamageEffect", 1);
        }
        if (other.gameObject.CompareTag("Finish")) {
            gameManager.WinGame();
        }

        if (other.gameObject.CompareTag("Check")) {
            // sound
            startPosition = other.transform.position;
        }
    }

    public void ResetToStartPosition() {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }

    private void EnableCoinEffect() {
        collectCoinEffect.SetActive(true);
        soundManager.PlayCoinSound();
    }

    private void EnableHealingEffect() {
        healingEffect.SetActive(true);
        soundManager.PlayLifeSound();
    }
    private void EnableDamageEffect() {
        damageEffect.SetActive(true);
        soundManager.PlayMonsterHitSound();
    }
    private void EnableWaterDamageEffect() {
        waterDamageEffect.SetActive(true);
        soundManager.PlayWaterSplashSound();
    }

    private void DisableCoinEffect() {
        collectCoinEffect.SetActive(false);
    }

    private void DisableHealingEffect() {
        healingEffect.SetActive(false);
    }
    private void DisableDamageEffect() {
        damageEffect.SetActive(false);
    }
    private void DisableWaterDamageEffect() {
        waterDamageEffect.SetActive(false);
    }
}

