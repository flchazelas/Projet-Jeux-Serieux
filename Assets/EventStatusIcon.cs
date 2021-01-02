using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventStatusIcon : MonoBehaviour
{
    public Sprite successIcon;
    public Sprite failureIcon;
    public Sprite timerIcon;

    public Image eventStatusIcon;

    private bool isEventWon;
    private int timer;
    private int maxTimer;

    private void Awake()
    {
        timer = 0;
        isEventWon = false;
    }

    public void updateEventStatus(bool isEventWon, int timer, int maxTimer)
    {
        this.isEventWon = isEventWon;
        this.timer = timer;
        this.maxTimer = maxTimer;

        if (timer == 0) //Event Done
        {
            eventStatusIcon.type = Image.Type.Simple;
            if (isEventWon)
                eventStatusIcon.sprite = successIcon;
            else
                eventStatusIcon.sprite = failureIcon;
        }
        else
        {
            eventStatusIcon.type = Image.Type.Filled;
            eventStatusIcon.fillMethod = Image.FillMethod.Radial360;
            eventStatusIcon.sprite = timerIcon;

            eventStatusIcon.fillAmount = ((float)timer) / ((float)maxTimer);
        }
    }
}
