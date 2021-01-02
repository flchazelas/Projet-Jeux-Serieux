using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventContainerUI : MonoBehaviour
{
    public Sprite refugeIcon;
    public Sprite intemperieIcon;
    public Sprite vagueIcon;
    public Sprite tacheIcon;

    public Image typeIcon;
    public Text title;
    public Text desc;
    public EventStatusIcon eventStatusIcon;

    public void updateTypeIcon(Evenement e)
    {
        if (e is Refuge)
        {
            typeIcon.sprite = refugeIcon;
        } else if (e is Intemperie)
        {
            typeIcon.sprite = intemperieIcon;
        }
        else if (e is Tache)
        {
            typeIcon.sprite = tacheIcon;
        }
        else if (e is Vague)
        {
            typeIcon.sprite = vagueIcon;
        }
    }

    public void updateTitle(string text)
    {
        title.text = text;
    }
    public void updateDesc(string text)
    {
        desc.text = text;
    }

    public void updateStatus(bool isEventWon, int timer, int maxTimer)
    {
        eventStatusIcon.updateEventStatus(isEventWon, timer, maxTimer);
    }
}
