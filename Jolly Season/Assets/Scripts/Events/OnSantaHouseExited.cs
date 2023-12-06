using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSantaHouseExited : MonoBehaviour
{
    KeyCode exitHome = KeyCode.Z;
    

    void Update()
    {
        CheckForZKey();
    }

    void CheckForZKey()
    {        
    if(Input.GetKeyDown(exitHome))
        {
            Actions.OnSantaHouseExited();
        }
    }
}
