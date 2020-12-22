using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fermier : Habitant
{
    private float allowedTime = 1;
    private float currentTime = 0;
    Vector3 vec1;
    Ressource ressource;
    bool travail;
    bool tache;
    int nbfois = 0;

    private void Awake()
    {
        Type = "Fermier";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        vec1 = Vec;
        base.Start();
        travail = false;
        tache = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (!IsActif)
        {
            Vec = vec1;
            V = vec1 - transform.position;
        }
        if (travail && !IsActif)
        {
            Travail();
        }
        if (tache && currentTime == 0 && nbfois < 5)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            Vec = new Vector3(Vec.x, Vec.y, Vec.z);
            V = new Vector3(0, 0, 0);
            IsActif = true;
            currentTime = allowedTime;
            GetComponent<Animator>().SetBool("isFighting", true);
            StartCoroutine("Timer");
        }
        if (nbfois >= 4)
        {
            Vec = vec1;
            V = vec1 - transform.position;
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isFighting", false);
            tache = false;
        }

        if (!isAlive())
        {
            GameVariables.listFermier.Remove(this);
        }
    }

    public void Travail()
    {
        calculDistance();
        nbfois = 0;
    }

    public void calculDistance()
    {
        float distance = 1000f;
        foreach (Ressource r in FindObjectsOfType<Champ>())
        {
            float val = Mathf.Sqrt(Mathf.Pow(transform.position.x - r.transform.position.x, 2f) + Mathf.Pow(transform.position.z - r.transform.position.z, 2f));
            if (val < distance && r.Capacite > 0)
            {
                distance = val;
                ressource = r;
            }
        }

        Vec = new Vector3(ressource.transform.position.x, 0, ressource.transform.position.z);
        V = Vec - transform.position;
        //ressource.Capacite--;
        //travail = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Champ"))
        {
            nbfois = 0;
            currentTime = allowedTime;
            IsActif = false;
            tache = false;
            ressource.Capacite++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Champ"))
        {
            tache = true;
            if(ressource.transform == collision.transform)
            {
                travail = false;
                ressource.Capacite--;
            }
        }

        if (collision.transform.CompareTag("Batiment") && collision.transform.CompareTag("Batiment") == Spawn)
        {
            travail = true;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        currentTime--;
        GetComponent<Animator>().SetBool("isFighting", false);
        nbfois++;
        travail = false;
    }
}
