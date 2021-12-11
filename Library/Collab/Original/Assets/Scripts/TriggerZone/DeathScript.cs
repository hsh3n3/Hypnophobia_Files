using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    private Transform upperEyeLid;
    private Transform lowerEyeLid;

    public GameObject checkpoint_controller;

    public InventoryObject inventory;

    private AudioSource deathSound;



    private float a = 0.0f;
    private bool isDead;


    public float speed = 0.33f;
    public float closeEyesSpeed = 1.0f;
    public bool instantDeath = false;


    private void Start()
    {
        
        isDead = false;
        upperEyeLid = GameObject.Find("First Person Player").GetComponent<Blink>().upperEyeLid;
        lowerEyeLid = GameObject.Find("First Person Player").GetComponent<Blink>().lowerEyeLid;
        deathSound = GameObject.Find("PlayerDeath (Audio)").GetComponent<AudioSource>();

    }

    private void Update()
    {


        // Debug.Log(isDead);
        if (isDead && !instantDeath)
        {
            if (a < 1f)
            {
                GameObject.Find("First Person Player").GetComponent<Blink>().blackScreen.color = new Color(0, 0, 0, a);
                a += speed * Time.deltaTime;
                upperEyeLid.transform.localPosition += new Vector3(0, -130, 0) * Time.deltaTime * closeEyesSpeed;
                lowerEyeLid.transform.localPosition += new Vector3(0, 130, 0) * Time.deltaTime * closeEyesSpeed;

            }
            if(a >= 1f)
            {
                GameObject.Find("First Person Player").GetComponent<Blink>().blackScreen.color = new Color(0, 0, 0, 1f);
                inventory.ClearInventory();
                Reload();
            }
        }
        else if(isDead && instantDeath)
        {
            GameObject.Find("First Person Player").GetComponent<PlayerMovement>().enabled = false;
            if (a < 1f)
            {
                GameObject.Find("First Person Player").GetComponent<Blink>().blackScreen.color = new Color(0, 0, 0, 1f);
                a += speed * Time.deltaTime;
            }
            if (a >= 1f)
            {
                inventory.ClearInventory();
                Reload();
            }
            

        }


    }
    void OnTriggerEnter(Collider collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            isDead = true;
            PlayDeathSound();
        }

    }


    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PlayDeathSound()
    {
        deathSound.Play();
    }

}
