using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class playerCollisionToSceneA : MonoBehaviour
{
    public string aScene;


     private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the specified tag
        if (other.CompareTag("goToSceneA"))
        {
            LoadSceneA();
        }
    }
    
    private void LoadSceneA()
    {
        if(!string.IsNullOrEmpty(aScene))
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Scene is not specified");
        }        
    }
}
