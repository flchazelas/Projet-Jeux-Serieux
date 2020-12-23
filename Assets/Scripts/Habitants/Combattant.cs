using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combattant : Habitant
{
    private float allowedTime = 1;
    private float currentTime = 0;
    Ennemi ennemi;

    public int pointsAttaque;

    protected override void Awake()
    {
        Type = "Combattant";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ennemi = null;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!isAlive())
        {
            GameVariables.listCombattant.Remove(this);
        }

        base.Update();
        if(FindObjectsOfType<Ennemi>().Length != 0 && !IsActif)
        {
            calculDistance();
        }
        else if(ennemi == null)
        {
            IsActif = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Ennemi"))
        {
            ennemi = collision.transform.GetComponent<Ennemi>();
            if (currentTime == 0)
            {
                GetComponent<Animator>().SetBool("isWalking", false);
                Vec = new Vector3(Vec.x, Vec.y, Vec.z);
                V = new Vector3(0, 0, 0);
                IsActif = true;
                currentTime = allowedTime;
                GetComponent<Animator>().SetBool("isFighting", true);
                StartCoroutine("Timer", ennemi);
            }
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            ennemi = other.GetComponent<Ennemi>();
            if (currentTime == 0)
            {
                GetComponent<Animator>().SetBool("isWalking", false);
                Vec = new Vector3(Vec.x, Vec.y, Vec.z);
                V = new Vector3(0, 0, 0);
                IsActif = true;
                currentTime = allowedTime;
                GetComponent<Animator>().SetBool("isFighting", true);
                StartCoroutine("Timer", ennemi);
            }
        }
    }*/

    public void calculDistance()
    {
        float distance = 1000f;
        foreach (Ennemi e in FindObjectsOfType<Ennemi>())
        {
            float val = Mathf.Sqrt(Mathf.Pow(transform.position.x - e.transform.position.x, 2f) + Mathf.Pow(transform.position.z - e.transform.position.z, 2f));
            if (val < distance)
            {
                distance = val;
                ennemi = e;
            }
        }

        Vec = new Vector3(ennemi.transform.position.x, ennemi.transform.position.y, ennemi.transform.position.z);
        V = Vec - transform.position;
    }

    IEnumerator Timer(Ennemi other)
    {
        yield return new WaitForSeconds(1);
        currentTime--;
        GetComponent<Animator>().SetBool("isFighting", false);
        if (other != null)
        {
            other.pointsVie -= pointsAttaque;
        }
    }
}
