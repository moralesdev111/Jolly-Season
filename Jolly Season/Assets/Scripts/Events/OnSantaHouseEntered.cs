using UnityEngine;

public class OnSantaHouseEnteredTrigger : MonoBehaviour
{   
    string sceneName = "goToSceneA";
     public void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag(sceneName))
        {
            Actions.OnSantaHouseEntered();
        }
    }           
    
}
