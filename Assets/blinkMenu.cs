using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform upperEyeLid;
    public Transform lowerEyeLid;
    public GameObject blinkCanvas;




    public float timer = 6f;



    private void Start()
    {


        upperEyeLid = GameObject.Find("UpperEyeLid").transform;
        lowerEyeLid = GameObject.Find("LowerEyeLid").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            OpenEyes();
        }
       

    }

    public void OpenEyes()
    {
        if (timer > 0)
        {
            upperEyeLid.transform.localPosition += new Vector3(0, 65, 0) * Time.deltaTime;
            lowerEyeLid.transform.localPosition += new Vector3(0, -65, 0) * Time.deltaTime;

            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            blinkCanvas.SetActive(false);
            upperEyeLid.gameObject.SetActive(false);
            lowerEyeLid.gameObject.SetActive(false);
        }
    }


}
