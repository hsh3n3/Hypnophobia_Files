using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class flowerpot_interact : MonoBehaviour
{
    //Plays an animation to move the flowerpot when clicked on.
    public void Interact()
    {
        this.gameObject.GetComponent<Animation>().Play();
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
