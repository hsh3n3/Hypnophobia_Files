using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(theText.gameObject.transform.parent.GetComponent<Button>().interactable == true)
        {
            theText.color = Color.red; //Or however you do your color

        }
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (theText.gameObject.transform.parent.GetComponent<Button>().interactable == true)
        {
            theText.color = Color.white; //Or however you do your color
        }
    }
}
