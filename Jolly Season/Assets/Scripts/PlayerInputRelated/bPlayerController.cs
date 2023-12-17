using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bPlayerController : MonoBehaviour
{
    

    [Header("Components")]
    [SerializeField] bPlayerInput bPlayerInput;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform townCamera;

    private bool detector; 
    RaycastHit raycastHit;
    [SerializeField] private float pickupRange = 10f;
    

    
    float turnSmoothVelocity;
    Vector3 velocity;

    [Header("Controls")]
    public float speed = 8f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f; 

      

    void Update()
    {
        DirectionHandler();
        bPlayerInput.PickupObject();
    }

    public void DirectionHandler()
    {
        if (bPlayerInput.direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(bPlayerInput.direction.x, bPlayerInput.direction.z) * Mathf.Rad2Deg + townCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply gravity to the character's movement
            velocity.y += gravity * Time.deltaTime;

            controller.Move((moveDir.normalized * speed + velocity) * Time.deltaTime);
        }
        else
        {
            // If not moving, reset the vertical velocity (to prevent constant falling)
            velocity.y = 0f;            
        }
    }

    public bool RayCasting()
    {        
        detector = Physics.Raycast(transform.position, transform.forward, out raycastHit, pickupRange);
        if(detector)
        {
            if(raycastHit.collider.CompareTag("PickUp"))
            Debug.Log("Object Detected");  
            return true;          
        }
        else
        {
            return false;
        }        
    }
    
}
    

