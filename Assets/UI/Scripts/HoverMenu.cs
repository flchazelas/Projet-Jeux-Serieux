using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup menu;
    public bool isMenuVisible;
    // Start is called before the first frame update
    void Start()
    {
        isMenuVisible = false;
        updateMenu();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMenuVisible = true;
        updateMenu();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMenuVisible = false;
        updateMenu();
    }

    private void updateMenu()
    {
        if (!isMenuVisible)
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
