using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopUp : MonoBehaviour
{
    public SwitchButton switchButton;
    public CanvasGroup menu;

    private bool isMenuVisible;

    // Start is called before the first frame update
    void Start()
    {
        isMenuVisible = false;
        updateMenu();
        switchButton.addListener(this.switchMenu);
    }

    public void switchMenu()
    {
        isMenuVisible = !isMenuVisible;
        updateMenu();
    }

    
    private void updateMenu()
    {
        if(!isMenuVisible)
        {
            menu.alpha = 0;
            menu.interactable = false;
            menu.blocksRaycasts = false;
        }
        else
        {
            menu.alpha = 1;
            menu.interactable = true;
            menu.blocksRaycasts = true;
        }
    }
}
