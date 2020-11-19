using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveau : MonoBehaviour
{
    public float timer;
    public int score = 0;
    public int difficulte = 0;
    public ListEvenements listEvenements;
    public float currentTimer = 0;
    public float laps;

    Text consigne;

    // Start is called before the first frame update
    void Start()
    {
        consigne = GameObject.Find("Canvas Evenement").transform.Find("Description").GetComponent<Text>();

        listEvenements = GameObject.Find("ListeEvenements").GetComponent<ListEvenements>();
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        lancerEvenement();
        affichage();
    }

    IEnumerator Timer()
    {
        while(currentTimer != laps)
        {
            yield return new WaitForSeconds(1);
            currentTimer++;
        }
        currentTimer = 0;
        if(listEvenements.getSize() != 0)
        {
            Evenement e = listEvenements.getEvent();
            Instantiate(e);
            StartCoroutine("Timer");
        }
        else
        {
            print("Fin du Niveau");
            print(score);
        }
    }

    public void affichage()
    {
        consigne.text = "";
        foreach (Evenement e in FindObjectsOfType<Evenement>())
        {
            consigne.text += e.description + "\n";
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
                Destroy(GameObject.Find(e.nom));
            }
        }
    }
}
