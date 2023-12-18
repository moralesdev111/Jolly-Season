using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillPresent : MonoBehaviour
{
    [SerializeField] Pickup pickup;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("PickUp"))
        {
            pickup.Destroy();
        }
    }
}
