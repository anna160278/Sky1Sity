using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.J)) {
            animator.SetTrigger("catJump");
        }    
    }
}
