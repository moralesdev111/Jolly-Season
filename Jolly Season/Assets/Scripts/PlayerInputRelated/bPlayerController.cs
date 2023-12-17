using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bPlayerController : MonoBehaviour
{   
    [Header("Components")]
    [SerializeField] bPlayerInput bPlayerInput;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform townCamera;        
    
    float turnSmoothVelocity;
    Vector3 velocity;

    [Header("Controls")]
    public float speed = 8f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f; 
    private bool detector; 
    RaycastHit raycastHit;
    [SerializeField] private float pickupRange = 10f;
    [SerializeField] GameObject pickupUI;

      
    void Update()
    {
        DirectionHandler();
        bPlayerInput.PickupObject();
        bPlayerInput.DropObject();
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

    public bool CheckIfYouCanPickUpObject()
    {        
        detector = Physics.Raycast(transform.position, transform.forward, out raycastHit, pickupRange);
        if(detector)
        {
            if(raycastHit.collider.CompareTag("PickUp"))
            Debug.Log("Object Picked Up");  
            return true;          
        }
        else
        {
            return false;
        }        
    }

    public void PickTheObject()
    {
        if(CheckIfYouCanPickUpObject())
        {
            raycastHit.collider.transform.SetParent(transform);
             raycastHit.collider.transform.localPosition = Vector3.one;
            raycastHit.collider.transform.localRotation = Quaternion.identity;
            pickupUI.SetActive(false);
        }
        bPlayerInput.hasObject = true;            
    }
    public void DropTheObject()
    {
        raycastHit.collider.transform.SetParent(null,true);
        pickupUI.SetActive(true);
        

    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PickUp") && bPlayerInput.hasObject == false)
        {
            pickupUI.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PickUp"))
        {
            pickupUI.SetActive(false);
        }        
    }    

    
}
    

