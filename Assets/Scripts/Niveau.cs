﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveau : MonoBehaviour
{
    public float timer;
    public int score = 0;
    public int difficulte = 0;
    public ListEvenements listEvenements;
    public float currentTimer;
    public float laps;

    Text consigne;

    // Start is called before the first frame update
    void Start()
    {
        consigne = GameObject.Find("Canvas Evenement").transform.Find("Description").GetComponent<Text>();

        listEvenements = GameObject.Find("ListeEvenements").GetComponent<ListEvenements>();
        for(int i = 0; i < listEvenements.getSize(); i++)
        {
            timer += listEvenements.getEvent(i).Duree + 2f*laps;
        }
        currentTimer = laps;
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
        while(currentTimer > 0)
        {
            yield return new WaitForSeconds(1);
            currentTimer--;
        }
        if(listEvenements.getSize() != 0)
        {
            Evenement e = listEvenements.getEvent();
            e = Instantiate(e);
            print("temps :" + e.Duree);
            currentTimer = e.Duree;
            if (listEvenements.getSize() == 0)
            {
                currentTimer += laps;
            }
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
                score += (int)e.Duree - (int)e.currentTimer;
                Destroy(GameObject.Find(e.nom));
            }
        }
    }
}