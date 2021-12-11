using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer; //main mixer.
    public string mixerName; //Name of mixer group (exposed paramater) to control volume of.
    public Slider slider;

    private void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(mixerName, 1f); //Default slider volume so it doesn't default to 0.
    }

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat(mixerName, Mathf.Log10(sliderValue)*20); //makes slidervalue logarithmic so that it better represents volume control over the standard method. 
        PlayerPrefs.SetFloat(mixerName, sliderValue);
    }

}
