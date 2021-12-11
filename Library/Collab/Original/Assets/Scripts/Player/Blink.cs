using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform upperEyeLid;
    public Transform lowerEyeLid;

    [HideInInspector]
    public GameObject blackScreenParent;
    [HideInInspector]
    public Image blackScreen;



    public float timer = 3f;



    private void Start()
    {
        blackScreenParent = GameObject.Find("BlackScreen");
        blackScreen = blackScreenParent.GetComponent(typeof(Image)) as Image;
        blackScreen.color = new Color(0, 0, 0, 0);


        upperEyeLid = GameObject.Find("UpperEyeLid").transform;
        lowerEyeLid= GameObject.Find("LowerEyeLid").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            upperEyeLid.transform.localPosition += new Vector3(0, 130, 0) * Time.deltaTime;
            lowerEyeLid.transform.localPosition += new Vector3(0, -130, 0) * Time.deltaTime;

            timer -= Time.deltaTime;
        }
        
    }


}
