using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialCleanup : MonoBehaviour
{
    int index = 0;
    public GameObject[] triggers;
    private void Start()
    {
        index = 0;
        Invoke("SetThoseBadBoys", 0.1f);
    }
    public void Increment()
    {
        index++;
        SetThoseBadBoys();
    }
    void SetThoseBadBoys()
    {
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].SetActive(i == index);
        }
    }
}
