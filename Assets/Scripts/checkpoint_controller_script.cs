using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;


public class checkpoint_controller_script: MonoBehaviour
{

    public InventoryObject inventory;

    public GameObject player;


    //these are so the player can teleport back to the location of the checkpoint.
    public Transform checkPoint1;
    public Transform checkPoint2;
    public Transform checkPoint3;


    public ItemObject flashlight;

    public GameObject deathWall;

    public GameObject flashlightObject;
    public GameObject keyObject;
    public GameObject doorObject;


    private float loadTimer = 0.05f;
    private bool doOnce;

    [HideInInspector]
    public int checkpoint_active; //to determine what checkpoint to return to.





    public void WriteCheckpoint(int checkPointNumber)
    {
        string path = Application.persistentDataPath + "/checkpoint.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(checkPointNumber); //Writes a single line, which is the active checkpoint.
        writer.Close();

        Debug.Log("Written to file.");

    }

    public void ClearCheckPoints()
    {
        string path = Application.persistentDataPath + "/checkpoint.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(""); 
        writer.Close();

        Debug.Log("Written to file.");

    }

    public void ReadCheckPoint()
    {
        string path = Application.persistentDataPath + "/checkpoint.txt";
        StreamReader reader = new StreamReader(path);
        string readLine = reader.ReadLine();

        if(readLine == "1")
        {
            checkpoint_active = 1;

            Debug.Log("File is being read.");
        }
        if (readLine == "2")
        {
            checkpoint_active = 2;

            Debug.Log("File is being read.");
        }
        if (readLine == "3")
        {
            checkpoint_active = 3;

            Debug.Log("File is being read.");
        }

        reader.Close();

    }

    // Start is called before the first frame update
    void Start()
    {
        inventory.ClearInventory();
        Reload_Checkpoint_Begin();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(loadTimer <= 0f)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        if(loadTimer >= 0f)
        {
            loadTimer -= Time.deltaTime;
        }


    }

    //This handles which checkpoint to reload to.
    public void Reload_Checkpoint_Begin()
    {
        //Checks which checkpoint was the last active one, and return you to it. 
        ReadCheckPoint();
            switch (checkpoint_active)
            {
                case 1:
                    Reload_Checkpoint_1();
                    break;
                case 2:
                    Reload_Checkpoint_2();
                    break;
                default:
                //This is in case something goes wrong with checkpoints, the level will just reload.
                break;
            }

        
       


    }


    //These will reset the player to the proper checkpoints when called.
    //The inventory and item reset portion of these will need to be modified for each level.
    public void Reload_Checkpoint_1()
    {
        //SET PLAYER POSITION
        player.transform.position = checkPoint1.position;//set player to respawn at the checkpoint.
        player.transform.rotation = checkPoint1.rotation;//set player rotation to the checkpoint.

        //DEACTIVATE CHECKPOINTS PRIOR TO THIS ONE
        checkPoint1.gameObject.SetActive(false);

        //MOVE OBJECTS TO PROPER LOCATIONS
        deathWall.transform.localPosition = new Vector3(466, 181.5f, 200);


    }

    public void Reload_Checkpoint_2()
    {
        //SET PLAYER POSITION
        player.transform.position = checkPoint2.position;//set player to respawn at the checkpoint.
        player.transform.rotation = checkPoint2.rotation;//set player rotation to the checkpoint.

        //ADD ITEMS NEEDED BY THIS CHECKPOINT
        inventory.AddItem(flashlight, 1);

        //DE-ACTIVATE ITEMS IN SCENE THAT WOULD HAVE ALREADY BEEN INTERACTED WITH
        flashlightObject.SetActive(false);
        keyObject.SetActive(false);

        //DEACTIVATE CHECKPOINTS PRIOR TO THIS ONE
        checkPoint1.gameObject.SetActive(false);
        checkPoint2.gameObject.SetActive(false); //This is this checkpoint, but its already activated so we don't need to activate it again.

        doorObject.layer = 0; //Setting it so door cannot be interacted.
        doorObject.GetComponent<Animation>().Play(); //door is permanently opened.

        //MOVE OBJECTS TO PROPER LOCATIONS
        deathWall.transform.localPosition = new Vector3(466, 181.5f, 400); //Moving deathwall forward. 




    }
}
