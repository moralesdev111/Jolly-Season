using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] bPlayerInput bPlayerInput;
    public bool hasObject = false;
    private bool detector; 
    RaycastHit raycastHit;
    [SerializeField] private float pickupRange = 10f;
    [SerializeField] GameObject pickupUI;
    private GameObject pickedObject;
    [SerializeField] Vector3 offsetFromPlayer = new Vector3(1f,0,1.4f);
  

    void Update()
    {
        bPlayerInput.PickupObject();
        bPlayerInput.DropObject();
    }

    
    public GameObject CheckIfYouCanPickUpObject()
    {        
        detector = Physics.Raycast(transform.position, transform.forward, out raycastHit, pickupRange);
        if(detector && raycastHit.collider.CompareTag("PickUp"))
        {
            return raycastHit.collider.gameObject;         
        }
        else
        {
            return null;
        }        
    }

    public void PickTheObject()
{
    GameObject obj = CheckIfYouCanPickUpObject();
    if(obj != null && pickedObject == null)
    {
        pickedObject = obj;
        obj.transform.SetParent(transform);
        obj.transform.localPosition = offsetFromPlayer; // Apply offset
        obj.transform.localRotation = Quaternion.identity;
        hasObject = true;
        pickupUI.SetActive(false); // Hide UI if the object is picked up
    }
}
    
    
public void DropTheObject()
{
    if (pickedObject != null)
    {
        
        pickedObject.transform.SetParent(null, true);
         // Drop directly beneath the player
        pickedObject = null;
        hasObject = false;
        pickupUI.SetActive(true); // Show UI when the object is dropped
    }
}
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PickUp") && hasObject == false)
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
