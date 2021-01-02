using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsUIUpdater : MonoBehaviour
{
    private static EventsUIUpdater instance = null;
    public static EventsUIUpdater getInstance() { return instance; }
    public EventsUI eventsUI;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void updateEventsUI(List<Evenement> evenements)
    {
        eventsUI.updateFromList(evenements);
    }
}
