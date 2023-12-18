using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas pickupUI;
    [SerializeField] Canvas sendOffUI;

    public void TurnOnPickupUI()
    {
        pickupUI.gameObject.SetActive(true);
    }

    public void TurnOffPickupUI()
    {
        pickupUI.gameObject.SetActive(false);
    }

    public void TurnOnSendOffUI()
    {
        sendOffUI.gameObject.SetActive(true);
    }
    public void TurnOffSendOffUI()
    {
        sendOffUI.gameObject.SetActive(false);
    }
}
