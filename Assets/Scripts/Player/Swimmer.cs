using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimmer : MonoBehaviour
{
    PlayerMovement Pm;
    public float playerDepth;

    public AudioSource audio;
    public AudioClip underWater;
    int count;
    public float lightIntensity = .1f;
    public GameObject Cover;
    public GameObject Cover2;
    // Start is called before the first frame update
    void Start()
    {

       
        

        Pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //  RenderSettings.fog = isUnderWater();
       

        playerDepth = gameObject.transform.position.y;

        if (isUnderWater())
        {

            //count used to make this code only run once
            count++;
            if(count == 1)
            {
                audio.Stop();
                audio.clip = underWater;
                audio.Play();
            }

            Cover.SetActive(true);
            Cover2.SetActive(true);



            RenderSettings.ambientIntensity = lightIntensity;
            RenderSettings.ambientSkyColor = new Color(0.0f, 0.0f, 0.0f);
            RenderSettings.fogColor = new Color(0.2f, 0.4f, 0.8f);
            RenderSettings.fogDensity = playerDepth * .0001f;

            Pm.walkSpeed = 2;
            Pm.runSpeed = 4;
            Pm.jumpSpeed = 3;
            Pm.gravity = 8;
       
            

        }
    }

    bool isUnderWater()
    {
        return gameObject.transform.position.y < -10f;
    }
}
