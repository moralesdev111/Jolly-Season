using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPlayerInput : MonoBehaviour
{
    [SerializeField] Pickup pickup;
    [HideInInspector] public Vector3 direction; 
   
    [SerializeField] KeyCode pickObject = KeyCode.F;
    public KeyCode dropObject = KeyCode.R;
    private float horizontal;
    private float vertical;      
    


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
            pickup.PickTheObject();
        }        
    }        

    public void DropObject()
    {
        if(Input.GetKeyDown(dropObject) && pickup.hasObject == true)
        {
            pickup.DropTheObject();            
        }        
    }
}
