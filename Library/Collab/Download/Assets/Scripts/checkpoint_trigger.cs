using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_trigger : MonoBehaviour
{
    // Start is called before the first frame update

    public int checkPointNumber;

    public GameObject checkpoint_controller;
    public GameObject playerCamera;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //The below code will set the active checkpoint in the main checkpoint controller for the level.
    //Make sure to set the check point number in the editor so the proper location data and active objects can be stored. 
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player")
        {
            checkpoint_controller.GetComponent<checkpoint_controller_script>().checkpoint_active = checkPointNumber;
            checkpoint_controller.GetComponent<checkpoint_controller_script>().WriteCheckpoint(checkPointNumber); //write checkpoint to a text file.


            playerCamera.GetComponent<RayInteract>().pickupText.text = "Checkpoint reached.";
            playerCamera.GetComponent<RayInteract>().pickupTextCountDown = 1;

            this.enabled = false;
        }


    }
}
