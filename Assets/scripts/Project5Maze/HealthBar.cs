using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBarImage;
    public GameManager5 gameManager5;
    void Start()
    {
        healthBarImage = GetComponent<Image>();
    }

 
    void Update()
    {
        healthBarImage.fillAmount = gameManager5.HP/gameManager5.maxHP;
    }
}
