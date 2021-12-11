using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; //Enable cursor for menu control.
        Cursor.lockState = CursorLockMode.Confined; //Confine cursor in screen.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
