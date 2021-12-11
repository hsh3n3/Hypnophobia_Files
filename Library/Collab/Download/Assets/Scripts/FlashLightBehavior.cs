using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightBehavior : MonoBehaviour
{
    public GameObject spotLight;
    [HideInInspector]
    public GameObject flashlight;
    public GameObject halo;

    public GameObject playerCamera;
    public bool flashLightOn = false;
    public InventoryObject inventory;
    private MeshRenderer flashlightRender;

    public AudioSource flashlightAudio;

    private bool doOnce;





    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.Find("PlayerFlashlight");
        halo = GameObject.Find("flashlight_halo");
        halo.SetActive(false);


        flashlightRender = flashlight.GetComponent<MeshRenderer>();

        doOnce = true;


    }

    // Update is called once per frame
    void Update()
    {
        var checkHasItem = flashlight.GetComponent<RemoveItemCheck>();
        if (inventory.RemoveItemCheck(checkHasItem.item) == true && doOnce)
        {
            flashlightAudio.Play();
            flashlightRender.enabled = true;
            spotLight.SetActive(true);
            halo.SetActive(true);
            doOnce = false;

            playerCamera.GetComponent<RayInteract>().pickupText.text = "Press F to toggle your flashlight on/off.";
            playerCamera.GetComponent<RayInteract>().pickupTextCountDown = 5;



        }
        else if (inventory.RemoveItemCheck(checkHasItem.item) == false)
        {
            flashlightRender.enabled = false;
            spotLight.SetActive(false);
            halo.SetActive(false);
            doOnce = true;
        }

        if (flashlightRender.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (flashLightOn == false)
                {
                    spotLight.SetActive(true);
                    halo.SetActive(true);
                    flashLightOn = true;
                    flashlightAudio.Play();
                }

                else
                {
                    halo.SetActive(false);
                    spotLight.SetActive(false);
                    flashLightOn = false;
                    flashlightAudio.Play();
                }
            }
        }

    }
}