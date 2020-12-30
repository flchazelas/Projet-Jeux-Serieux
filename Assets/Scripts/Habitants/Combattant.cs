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
            Destroy(random_object);
            GameVariables.listCombattant.Remove(this);
        }

        base.Update();
        if(searchEnnemi())
        {
            target = ennemi.transform;
        }
        else if(ennemi == null)
        {
            target = random_object.transform;
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
                
                currentTime = allowedTime;
                GetComponent<Animator>().SetBool("isFighting", true);
                StartCoroutine("Combattre", ennemi);
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

    public bool searchEnnemi()
    {
        float closestEnnemi = 1000f;
        foreach (Ennemi e in FindObjectsOfType<Ennemi>())
        {
            float val = Vector3.Distance(transform.position, e.transform.position);
            if (val < closestEnnemi)
            {
                closestEnnemi = val;
                ennemi = e;
            }
        }
        if (closestEnnemi == 1000f)
        {
            ennemi = null;
            return false;
        }
        
        return true;
    }

    IEnumerator Combattre(Ennemi other)
    {
        agent.isStopped = true;
        transform.forward=other.transform.position-transform.position;

        yield return new WaitForSeconds(1);
        currentTime--;
        GetComponent<Animator>().SetBool("isFighting", false);
        if (other != null)
        {
            other.pointsVie -= pointsAttaque;
        }
        agent.isStopped = false;
    }
}
