using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPlayerInput : MonoBehaviour
{
    float horizontal, vertical;
    [HideInInspector]
    public Vector3 direction; 

    [SerializeField] bPlayerController bPlayerController;
    [SerializeField] KeyCode pickObject = KeyCode.F;
    
    

    
    void Update()
    {
        PlayerInput();
    }

    public void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }

    public void PickupObject()
    {
        if(Input.GetKeyDown(pickObject))
        {
            bPlayerController.RayCasting();
        }
    }

    
}
