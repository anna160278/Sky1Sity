using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4 : MonoBehaviour
{
    private Transform player;
    private Vector3 direction;
    private float speed = 3f;
    private float attackRange = 3f;
    private float distanceToPlayer;
    void Start()
    {
        player = GameObject.Find("player4").transform;
    }
    
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= attackRange) {
            direction = (player.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }
}
