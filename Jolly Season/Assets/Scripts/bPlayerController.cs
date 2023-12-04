using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bPlayerController : MonoBehaviour
{
    public bPlayerInput bPlayerInput;
    public CharacterController controller;
    public Transform townCamera;
    public float speed = 8f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f; 
    float turnSmoothVelocity;
    Vector3 velocity;


    void Update()
    {
        DirectionHandler();
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

            // Apply movement
            controller.Move((moveDir.normalized * speed + velocity) * Time.deltaTime);
        }
        else
        {
            // If not moving, reset the vertical velocity (to prevent constant falling)
            velocity.y = 0f;

            // Check if the defined key is pressed

        }
    }
}
    

