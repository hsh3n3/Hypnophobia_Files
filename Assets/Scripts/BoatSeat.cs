using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSeat : MonoBehaviour
{


    public float accelerateSpeed = 1000f;
    public float turnSpeed = 20f;

    private Rigidbody rbody;
    public CharacterController cc;
    public GameObject player;
    public GameObject playerBody;
    Transform defaultPlayerTransform;

    bool isDriving = false;

    private void Start()
    {
      //  cc = GameObject.FindObjectOfType<CharacterController>();
      //  player = cc.gameObject;
        defaultPlayerTransform = player.transform.parent;
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
     if(Input.GetKeyDown(KeyCode.E) && IsNearBoat())
        {
            SetDriving(!isDriving);
            System.Console.WriteLine("Player is Driving!");
        }

        if (isDriving)
        {
            if (Input.GetKeyDown("w"))
            {

                rbody.AddForce(transform.forward * -accelerateSpeed, ForceMode.Acceleration);

            }

            if (Input.GetKeyDown("s"))
            {

                rbody.AddForce(transform.forward * accelerateSpeed, ForceMode.Acceleration);

            }

            if (Input.GetKeyDown("a"))
            {

                rbody.AddForce(0f, turnSpeed * Time.deltaTime, 0f);

            }
        }
        

    }


    void SetDriving(bool isDriving)
    {
        this.isDriving = isDriving;

        cc.enabled = !isDriving;

        if (isDriving)
        {
            player.transform.parent = gameObject.transform;
        }
        else
        {
            player.transform.parent = defaultPlayerTransform;
        }
    }

    bool IsNearBoat()
    {
        return Vector3.Distance(gameObject.transform.position, playerBody.transform.position) < 2.9;
    }
   

}
