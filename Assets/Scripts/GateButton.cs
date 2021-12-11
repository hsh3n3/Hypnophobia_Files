using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateButton : MonoBehaviour
{

    public GameObject yellowWire;
    public GameObject greenWire;
    public GameObject redWire;

    public GameObject gate;

    public GameObject playerCamera;

    public AudioClip buttonPressSound;

    private AudioSource buttonPress;

    private float cooldown;



    public void Start()
    {
        buttonPress = this.gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (cooldown >= 0.0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void Interact()
    {
        if(cooldown <= 0.0f)
        {
            if (yellowWire.activeSelf == true && greenWire.activeSelf == true && redWire.activeSelf && true)
            {
                //Will put your code here



                cooldown = 1.0f;
                this.gameObject.layer = 0; //To disable the button after use
                buttonPress.Play();
                playerCamera.GetComponent<RayInteract>().pickupText.text = "The nearby gate opens...";
                playerCamera.GetComponent<RayInteract>().pickupTextCountDown = 1;
                gate.GetComponent<Animation>().Play();
                gate.GetComponent<AudioSource>().Play();


            }
            else
            {
                cooldown = 1.0f;
                buttonPress.Play();
                playerCamera.GetComponent<RayInteract>().pickupText.text = "Nothing happens...";
                playerCamera.GetComponent<RayInteract>().pickupTextCountDown = 1;



            }
        }
        
        
    }
}
