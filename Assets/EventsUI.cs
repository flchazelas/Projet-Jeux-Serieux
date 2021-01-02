using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsUI : MonoBehaviour
{
    public GameObject eventContainerPrefab;
    public GameObject separatorPrefab;

    public GameObject contentObject;

    private List<Evenement> evenements;
    private Dictionary<Evenement, EventContainerUI> evenementsContainers;

    private void Update()
    {
        if(this.evenements != null)
            foreach (Evenement e in this.evenements)
            {
                updateEventContainer(e);
            }
    }

    public void updateFromList(List<Evenement> evenements)
    {
        this.evenements = evenements;
        evenementsContainers = new Dictionary<Evenement, EventContainerUI>();
        foreach (Transform child in contentObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        int i = 0;
        foreach (Evenement e in this.evenements)
        {
            if (i != 0)
            {
                GameObject separator = Instantiate(separatorPrefab);
                separator.transform.parent = contentObject.transform;
                separator.transform.localScale = new Vector3(1,1,1);
            }

            GameObject container = Instantiate(eventContainerPrefab);
            container.transform.parent = contentObject.transform;
            container.transform.localScale = new Vector3(1, 1, 1);

            EventContainerUI eventContainerUI = container.GetComponent<EventContainerUI>();
            evenementsContainers.Add(e, eventContainerUI);

            updateEventContainer(e);
            i++;
        }


    }
    private void updateEventContainer(Evenement e)
    {
        EventContainerUI eventContainerUI = null;

        if (!evenementsContainers.TryGetValue(e, out eventContainerUI) && eventContainerUI != null)
            return;

        //Update Type Icon
        eventContainerUI.updateTypeIcon(e);

        //Update Title
        eventContainerUI.updateTitle(e.nom);

        //Update Desc
        eventContainerUI.updateDesc(e.description);

        //Update Status Icon
        eventContainerUI.updateStatus(e.objectifReussi,(int)(e.duree - e.currentTimer), (int)e.duree);
    }
}
