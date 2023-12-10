using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    [SerializeField] Waypoints waypoints;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float distanceThreshold = 0.1f;
    [SerializeField] private float rotateSpeed = 5f; // Adjusted the rotateSpeed
    Transform currentWaypoint;
    private Quaternion rotationGoal;
    private Vector3 directionTowardWaypoint;

    
    void Start()
    {
        SetupDirection();
    
    }

    

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        RotateTowardsCurrentWaypoint();
        ContinueNextWayPoint();
    }

    private void ContinueNextWayPoint()
    {
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        }
    }

    void SetupDirection()
    {
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;
    }

    void RotateTowardsCurrentWaypoint()
    {
        directionTowardWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionTowardWaypoint);

        // Use RotateTowards instead of Slerp for smoother rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
