using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    // This script is a collection of functions to help control the main menu functionality.
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public Text wideScreenText;

    public InventoryObject inventory;

    public bool optionsEnabled = false;

    public bool fourByThree = false;
    public bool fiveByFour = false;
    public bool sixteenByNine = true; //default aspect ratio
    public bool sixteenByTen = false;

    [HideInInspector]
    public bool wideEnabled;

    public int wideScreenOption;



    public void Start()
    {


        wideScreenOption = PlayerPrefs.GetInt("Widescreen"); //retrieve saved widescreen info.
        Time.timeScale = 1.0f;


        //Initial loading for widescreen info.
        if (wideScreenOption == 0)
        {
            Screen.SetResolution(960, 720, true);
            fourByThree = true;
            fiveByFour = false;
            sixteenByNine = false;
            sixteenByTen = false;
            wideScreenText.text = "Aspect Ratio: 4:3";

        }
        else if (wideScreenOption == 1)
        {
            Screen.SetResolution(960, 540, true);
            fourByThree = false;
            fiveByFour = false;
            sixteenByNine = true;
            sixteenByTen = false;
            wideScreenText.text = "Aspect Ratio: 16:9";

        }
        else if (wideScreenOption == 2)
        {
            Screen.SetResolution(960, 600, true);
            fourByThree = false;
            fiveByFour = false;
            sixteenByNine = false;
            sixteenByTen = true;
            wideScreenText.text = "Aspect Ratio: 16:10";

        }
        else if (wideScreenOption == 3)
        {
            Screen.SetResolution(960, 768, true);
            fourByThree = false;
            fiveByFour = true;
            sixteenByNine = false;
            sixteenByTen = false;
            wideScreenText.text = "Aspect Ratio: 5:4";

        }
    }



    public void ToggleOptionsMenu()
    {
        if (optionsEnabled)
        {
            //disable
            optionsMenu.GetComponent<Canvas>().enabled = false; //disable sub menu
            mainMenu.GetComponent<Canvas>().enabled = true; // re enable main menu
            optionsEnabled = false;
            
        }
        else
        {
            //enable
            optionsMenu.GetComponent<Canvas>().enabled = true; //enable sub menu
            mainMenu.GetComponent<Canvas>().enabled = false; //disable main menu
            optionsEnabled = true;

            

        }

    }

    public void NewGame(string level)
    {
      inventory.ClearInventory();
      SceneManager.LoadScene(level);


    }

    public void ContinueGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void SetWidescreen()
    {
        //Determining what setting is currently active and cycling to next one. 4:3 > 16:9 > 16:10 and so on.
        if (fiveByFour && !sixteenByTen && !fourByThree && !sixteenByNine)
        {
            Screen.SetResolution(960, 720, true);
            wideScreenText.text = "Aspect Ratio: 4:3";
            fourByThree = true;
            sixteenByNine = false;
            sixteenByTen = false;
            fiveByFour = false;
            PlayerPrefs.SetInt("Widescreen", 0); //set player prefs so it saves for next time game is loaded.
        }
        else if (fourByThree && !sixteenByNine && !sixteenByTen && !fiveByFour)
        {
            Screen.SetResolution(960, 540, true);
            wideScreenText.text = "Aspect Ratio: 16:9";
            fourByThree = false;
            sixteenByNine = true;
            sixteenByTen = false;
            fiveByFour = false;
            PlayerPrefs.SetInt("Widescreen", 1); //set  player prefs so it saves for next time game is loaded.
        }
        else if (sixteenByNine && !fourByThree && !sixteenByTen && !fiveByFour)
        {
            Screen.SetResolution(960, 800, true);
            wideScreenText.text = "Aspect Ratio: 16:10";
            fourByThree = false;
            sixteenByNine = false;
            sixteenByTen = true;
            fiveByFour = false;
            PlayerPrefs.SetInt("Widescreen", 2); //set player prefs so it saves for next time game is loaded.

        }

        else if (sixteenByTen && !sixteenByNine && !fourByThree && !fiveByFour)
        {
            Screen.SetResolution(960, 768, true);
            wideScreenText.text = "Aspect Ratio: 5:4";
            fourByThree = false;
            sixteenByNine = false;
            sixteenByTen = false;
            fiveByFour = true;
            PlayerPrefs.SetInt("Widescreen", 3); //set player prefs so it saves for next time game is loaded.

        }

    }
}
