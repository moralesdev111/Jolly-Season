using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    
    [SerializeField] Pickup pickup;
    [SerializeField] GameObject parentTrain;
    [SerializeField] Vector3 offsetFromTrain = new Vector3(0.6f,4.8f,-6f);
    bool isInsideDropoffArea = false;
public GameObject sentObject;


    void Update()
    {
        CheckIfCanDrop();
    }

    private void CheckIfCanDrop()
    {
        if (isInsideDropoffArea)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                FinalDropOff();
            }
        }
    }

    public  void FinalDropOff()
    {
        if (pickup.pickedObject != null)
    {
        
        pickup.pickedObject.transform.SetParent(parentTrain.transform);
        pickup.pickedObject.transform.localPosition = offsetFromTrain; // Apply offset
        pickup.pickedObject.transform.localRotation = Quaternion.identity;
         // Drop directly beneath the player
        sentObject = pickup.pickedObject;
        pickup.pickedObject = null;
        pickup.hasObject = false;        
    }
    }

    void OnTriggerStay(Collider other){
        if(other.CompareTag("DropPoint"))
        {
            isInsideDropoffArea = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("DropPoint"))
        {
            isInsideDropoffArea = false;
        }
    }

    

    
}
