using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas pickupUI;

    public void TurnOnPickupUI()
    {
        pickupUI.gameObject.SetActive(true);
    }

    public void TurnOffPickupUI()
    {
        pickupUI.gameObject.SetActive(false);
    }
}
