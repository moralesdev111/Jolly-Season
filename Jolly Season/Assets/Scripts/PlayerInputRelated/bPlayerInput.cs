using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bPlayerInput : MonoBehaviour
{
    [HideInInspector] public Vector3 direction; 
    [SerializeField] bPlayerController bPlayerController;
    [SerializeField] KeyCode pickObject = KeyCode.F;
    [SerializeField] KeyCode dropObject = KeyCode.R;
    private float horizontal;
    private float vertical;      
    public bool hasObject = false;


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
    {        if(Input.GetKeyDown(pickObject))
        {            
            bPlayerController.CheckIfYouCanPickUpObject();
            bPlayerController.PickTheObject();
        }        
    }        

    public void DropObject()
    {
        if(Input.GetKeyDown(dropObject) && hasObject == true)
        {
            bPlayerController.DropTheObject();
            Debug.Log("Drop Object");
        }
        
    }
}
