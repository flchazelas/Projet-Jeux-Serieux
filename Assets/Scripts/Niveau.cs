using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveau : MonoBehaviour
{
    private float timer;
    public int score = 0;
    public int difficulte = 0;
    public ListEvenements listEvenements;

    public List<Evenement> evenementsActifs;

    public ListEvenements listEvents;
    public float currentTimer;
    public float laps;

    private bool perdu;
    
    Text consigne;
    Text fin;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        score += 1000;
        perdu = false;
        image = GameObject.Find("Canvas Principal").transform.Find("Image").GetComponent<Image>();
        fin = image.transform.Find("Fin").GetComponent<Text>();

        listEvenements = GameObject.Find("ListeEvenements").GetComponent<ListEvenements>();
        int rand = Random.Range(5, 15);
        for(int i = 0; i<rand; i++)
        {
            listEvents.AddEvent(listEvenements.getEvent(Random.Range(0, listEvenements.getSize())));
        }

        for(int i = 0; i < listEvents.getSize(); i++)
        {
            timer += listEvents.getEvent(i).getDuree();
        }
        timer += 2.0f * laps;
        GameVariables.timer = timer;
        currentTimer = laps;
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        lancerEvenement();
        if(GameVariables.nbHabitants <= 0)
        {
            perdu = true;
        }
    }

    IEnumerator Timer()
    {
        while (currentTimer > 0 && !perdu)
        {
            yield return new WaitForSeconds(1);
            currentTimer--;
        }
        if (perdu)
        {
            StartCoroutine("Fin", "Game Over!\nVous n'avez plus d'habitant !");
            image.enabled = true;
            image.GetComponent<Animation>().Play();
        }
        else if(listEvents.getSize() != 0)
        {
            Evenement e = listEvents.getEvent();
            e = Instantiate(e);
            evenementsActifs.Add(e);
            EventsUIUpdater.getInstance().updateEventsUI(evenementsActifs);
            print("temps :" + e.getDuree());
            currentTimer = e.getDuree();
            if (listEvents.getSize() == 0)
            {
                currentTimer += laps;
            }
            StartCoroutine("Timer");
        }
        else if(listEvents.getSize() == 0 && FindObjectOfType<Evenement>())
        {
            StartCoroutine("Fin", "Game Over!\nVous n'avez pas fini tous les évènements !");
            image.enabled = true;
            image.GetComponent<Animation>().Play();
        }
        else
        {
            StartCoroutine("Fin", "Fin du niveau !\nVoici votre score : "+score);
            image.enabled = true;
            image.GetComponent<Animation>().Play();
        }
    }

    public void lancerEvenement()
    {
        foreach(Evenement e in FindObjectsOfType<Evenement>())
        {
            if (e.objectifReussi)
            {
                print("Fin : " + e.description);
                score += (int)e.duree - (int)e.currentTimer;
                evenementsActifs.Remove(e);
                EventsUIUpdater.getInstance().updateEventsUI(evenementsActifs);
                Destroy(e.gameObject);
            }
        }
    }

    IEnumerator Fin(string text)
    {
        yield return new WaitForSeconds(3);
        fin.text = text;
        fin.enabled = true;
    }
}
