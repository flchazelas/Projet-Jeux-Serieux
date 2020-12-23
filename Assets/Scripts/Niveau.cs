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
        consigne = GameObject.Find("Canvas Evenement").transform.Find("Description").GetComponent<Text>();
        image = GameObject.Find("Canvas Principal").transform.Find("Image").GetComponent<Image>();
        fin = image.transform.Find("Fin").GetComponent<Text>();

        listEvenements = GameObject.Find("ListeEvenements").GetComponent<ListEvenements>();
        for(int i = 0; i < listEvenements.getSize(); i++)
        {
            timer += listEvenements.getEvent(i).getDuree();
        }
        timer += 2.0f * laps;
        currentTimer = laps;
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        lancerEvenement();
        affichage();
        if(GameVariables.nbHabitants == 0)
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
            image.GetComponent<Animation>().Play();
        }
        else if(listEvenements.getSize() != 0)
        {
            Evenement e = listEvenements.getEvent();
            e = Instantiate(e);
            print("temps :" + e.getDuree());
            currentTimer = e.getDuree();
            if (listEvenements.getSize() == 0)
            {
                currentTimer += laps;
            }
            StartCoroutine("Timer");
        }
        else if(listEvenements.getSize() == 0 && FindObjectOfType<Evenement>())
        {
            StartCoroutine("Fin", "Game Over!\nVous n'avez pas fini tous les évènements !");
            image.GetComponent<Animation>().Play();
        }
        else
        {
            StartCoroutine("Fin", "Fin du niveau !\nVoici votre score : "+score);
            image.GetComponent<Animation>().Play();
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

    IEnumerator Fin(string text)
    {
        yield return new WaitForSeconds(3);
        fin.text = text;
        fin.enabled = true;
    }
}
