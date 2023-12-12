using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField ]SoundManager soundManager;
    [SerializeField] private Waypoints waypoints; // reference to waypoint system
    [Header("Movement Settings")]
    [SerializeField ]private float movementSpeed = 40f;   
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float stopWaitTime = 3f;
    [Header("Stop Location")]
    [SerializeField] private Transform stop;
    private float distanceThreshold = 0.1f;
    private Transform currentWaypoint;
    private Quaternion rotationGoal;
    private Vector3 directionToWaypoint;
    private bool isAtAStop = false;



    void Start()
    {
        SetPositionToStart();
    }   

    void Update()
    {
        if(!isAtAStop)
        {
            Moving();
        }        
    }    

    private void SetPositionToStart()
    {
        //set initial position
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //set next waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    private void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            if(currentWaypoint == stop)
            {
                StartCoroutine(TrainStop(stopWaitTime));    
            }
            else
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            }
                 
        }
        RotateTowardsWaypoint();
    }

    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position-transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotationGoal, rotationSpeed * Time.deltaTime);
    }

    IEnumerator TrainStop(float seconds)
    {
        isAtAStop = true;
        yield return new WaitForSeconds(seconds);
        soundManager.PlaySFX("Train");
        isAtAStop = false;
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }
}
