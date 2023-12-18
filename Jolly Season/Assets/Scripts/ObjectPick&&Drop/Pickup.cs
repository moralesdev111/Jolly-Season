using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
     [SerializeField] DropOff dropOff;
    [SerializeField] bPlayerInput bPlayerInput;
    public bool hasObject = false;
    private bool detector; 
    RaycastHit raycastHit;
    [SerializeField] private float pickupRange = 10f;
    [SerializeField] UIManager uIManager;
    public GameObject pickedObject;
    [SerializeField] Vector3 offsetFromPlayer = new Vector3(1f,0,1.4f);
  

    void Update()
    {
        bPlayerInput.PickupObject();
        bPlayerInput.DropObject();
    }

    
    public GameObject ReturnPickedGameObject()
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
    GameObject obj = ReturnPickedGameObject();
    if(obj != null && pickedObject == null)
    {
        pickedObject = obj;
        obj.transform.SetParent(transform);
        obj.transform.localPosition = offsetFromPlayer; // Apply offset
        obj.transform.localRotation = Quaternion.identity;
        hasObject = true;
        uIManager.TurnOffPickupUI(); // Hide UI if the object is picked up
    }
}
    
    
public virtual void DropTheObject()
{
    if (pickedObject != null)
    {
        
        pickedObject.transform.SetParent(null, true);
         // Drop directly beneath the player
        pickedObject = null;
        hasObject = false;
        uIManager.TurnOnPickupUI(); // Show UI when the object is dropped
    }
}
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PickUp") && hasObject == false)
        {
            uIManager.TurnOnPickupUI();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PickUp"))
        {
            uIManager.TurnOffPickupUI();
        }        
    }    

    public void Destroy()
    {
        Destroy(dropOff.sentObject);
    }
}
