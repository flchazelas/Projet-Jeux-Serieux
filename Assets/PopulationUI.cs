using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulationUI : MonoBehaviour
{
    public Button upButton;
    public Button downButton;
    public TMP_Text popTextCounter;

    public void Start()
    {
        setPopCounter(0);
        upButton.gameObject.SetActive(false);
        downButton.gameObject.SetActive(false);
    }

    public void setPopCounter(int popNumber)
    {
        popTextCounter.text = popNumber.ToString();
    }

    public void setUpAction(UnityEngine.Events.UnityAction listener)
    {
        upButton.onClick.AddListener(() => {
            listener.Invoke();
        });
    }

    public void setDownAction(UnityEngine.Events.UnityAction listener)
    {
        downButton.onClick.AddListener(() => {
            listener.Invoke();
        });
    }
    public void enableUpAction()
    {
        upButton.gameObject.SetActive(true);
    }
    public void disableUpAction()
    {
        upButton.gameObject.SetActive(false);
    }
    public void enableDownAction()
    {
        downButton.gameObject.SetActive(true);
    }
    public void disableDownAction()
    {
        downButton.gameObject.SetActive(false);
    }
}
