using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenuController : MonoBehaviour
{

    public bool pauseEnabled = false;
    public bool fourByThree = false;
    public bool fiveByFour = false;
    public bool sixteenByNine = true;
    public bool sixteenByTen = false;
    public Canvas pauseCanvas;
    public Canvas controlsCanvas;
    public Camera playerCamera;
    public Text wideScreenText;
    public int wideScreenOption;


    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("First Person Camera").GetComponent<Camera>();
        pauseCanvas = GameObject.Find("PauseMenu").GetComponent<Canvas>();
        pauseCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        wideScreenOption = PlayerPrefs.GetInt("Widescreen"); //retrieve saved widescreen info.


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
        else if(wideScreenOption == 3)
        {
            Screen.SetResolution(960, 768, true);
            fourByThree = false;
            fiveByFour = true;
            sixteenByNine = false;
            sixteenByTen = false;
            wideScreenText.text = "Aspect Ratio: 5:4";

        }

    }

    // Update is called once per frame
    void Update()
    {
        //To toggle on/off pause menu
        if ((Input.GetKeyDown(KeyCode.Escape) && !pauseEnabled) || Input.GetKeyDown(KeyCode.P) && !pauseEnabled)
        {
            ShowPauseMenu(); //Toggled on
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && pauseEnabled ) || Input.GetKeyDown(KeyCode.P) && pauseEnabled)
        {
            HideAllMenus(); //Toggled off
        }

    }


    public void ShowPauseMenu()
    {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0.0f;
            playerCamera.GetComponent<MouseLook>().enabled = false;
            pauseCanvas.enabled = true;
            pauseEnabled = true;
    }

    public void HidePauseMenu()
    {
        pauseCanvas.enabled = false;
        pauseEnabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        playerCamera.GetComponent<MouseLook>().enabled = true;
        controlsCanvas.enabled = false;
    }

    public void ShowControls()
    {
        pauseCanvas.enabled = false;
        controlsCanvas.enabled = true;
    }
    
    public void HideControls()
    {
        pauseCanvas.enabled = true;
        controlsCanvas.enabled = false;
    }

    public void HideAllMenus()
    {
        pauseEnabled = false;
        pauseCanvas.enabled = false;
        controlsCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        playerCamera.GetComponent<MouseLook>().enabled = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string levelName)
    {
        pauseEnabled = false;
        ShowPauseMenu(); //Toggled off
        SceneManager.LoadScene(levelName);
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
        else if (fourByThree && !sixteenByNine && !sixteenByTen &&!fiveByFour)
        {
            Screen.SetResolution(960, 540, true);
            wideScreenText.text = "Aspect Ratio: 16:9";
            fourByThree = false;
            sixteenByNine = true;
            sixteenByTen = false;
            fiveByFour = false;
            PlayerPrefs.SetInt("Widescreen", 1); //set  player prefs so it saves for next time game is loaded.
        }
        else if (sixteenByNine && !fourByThree && !sixteenByTen &&!fiveByFour)
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
