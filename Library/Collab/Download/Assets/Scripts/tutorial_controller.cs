using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial_controller : MonoBehaviour
{
    public GameObject playerCamera;

    public InventoryObject inventory;

    [TextArea]
    public string message;

    public bool disableAfterTrigger;

    private void Start()
    {
        inventory.ClearInventory();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           
            playerCamera.GetComponent<RayInteract>().pickupText.text = message;
            playerCamera.GetComponent<RayInteract>().pickupTextCountDown = 5;


            if (disableAfterTrigger)
            {
                FindObjectOfType<tutorialCleanup>().Increment();
            }
           

           
        }
    }

}
