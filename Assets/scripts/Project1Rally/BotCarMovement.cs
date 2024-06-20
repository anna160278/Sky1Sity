using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCarMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;  // создаём список из waypoints
    public float moveSpeed = 10f;
    private float turnSpeed = 5f;
    private int waypointIndex = 0;


    private void Update() {
        MoveToWaypoint();
        TurnTowardsWaypoint();
    }

    private void MoveToWaypoint() {
        if (waypointIndex <= waypoints.Count - 1) {
            Transform targetWaypoint = waypoints[waypointIndex];
            Vector3 targetPosition = targetWaypoint.position;
            Vector3 movementThisFrame = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.position = movementThisFrame;

            if (transform.position == targetPosition) {
                waypointIndex++;
                if (waypointIndex == waypoints.Count) 
                {
                    waypointIndex = 0;
                }
            }
        }
    }

    private void TurnTowardsWaypoint() {
        if (waypointIndex <= waypoints.Count - 1) {
            Vector3 directionToTarget = waypoints[waypointIndex].position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}
