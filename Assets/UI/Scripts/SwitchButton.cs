using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchButton : MonoBehaviour
{
    public Image icon; 
    public TMP_Text text;

    public Sprite onIcon;
    public Sprite offIcon;

    public string onText;
    public string offText;

    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        updateButton();
        this.addListener(this.switchButton);
    }

    public void switchButton()
    {
        isOn = !isOn;
        updateButton();
    }

    public void addListener(UnityEngine.Events.UnityAction listener)
    {
        this.GetComponent<Button>().onClick.AddListener(() => {
            listener.Invoke();
        });
    }

    private void updateButton()
    {
        if (!isOn)
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        if (icon == null && text == null)
            return;

        if (!isOn)
        {
            icon.sprite = offIcon;
            text.text = offText;
        }
        else
        {
            icon.sprite = onIcon;
            text.text = onText;
        }
    }

    public void triggerOnClick()
    {
        this.GetComponent<Button>().onClick.Invoke();
    }
}
