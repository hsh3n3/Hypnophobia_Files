using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDisable;
    public bool disableAfterActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Interact()
    {
        objectToActivate.SetActive(true);

        if (disableAfterActivate){
            objectToDisable.layer = 0; //Changes layer to none so that it is no longer interactable.
        }
    }
}
