using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : Habitant
{
    private float allowedTime = 1;
    private float currentTime = 0;
    Vector3 spawnPosition;
    Ressource ressource;

    
    

    Transform workplace;

    
    public enum WorkplaceType
    {
        Champ,
        Rocher,
        Arbre
    };
    public WorkplaceType workplaceType;
    public string workType;
    protected string ressourceStr;
    public float workDuration;

    private bool isWorking;
    private bool isReturningToSpawn;
    private bool isGoingToWork;

    protected override void Awake()
    {
        
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Destroy(random_object);
        isWorking = false;
        isReturningToSpawn = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!isAlive())
        {
            GameVariables.listFermier.Remove(this);
        }
        base.Update();

        if (!isWorking)
        {
            if (isReturningToSpawn)
            {
                print("go Spawn");
                target = Spawn.transform;
            }
            else if (isGoingToWork)
            {
                target = workplace;
            }
            else
            {
                agent.isStopped = true;
                isGoingToWork=searchForWork();
                if (isGoingToWork)
                    agent.isStopped = false;

            }

        }
        
        
    }


    public bool searchForWork()
    {
        float closestWorkplaceDist = 1000f;

        switch (workplaceType)
        {
            case WorkplaceType.Champ:
                foreach (Ressource r in FindObjectsOfType<Champ>())
                {
                    float val = Vector3.Distance(transform.position, r.transform.position);
                    if (val < closestWorkplaceDist && r.Capacite > 0 && agent.CalculatePath(r.transform.position, new UnityEngine.AI.NavMeshPath()))
                    {
                        closestWorkplaceDist = val;
                        ressource = r;
                    }
                }
                ressource.Capacite--;
                workplace = ressource.transform;
                if(closestWorkplaceDist!= 1000f)
                    return true;
                break;


            case WorkplaceType.Arbre:
                foreach (Ressource r in FindObjectsOfType<Arbre>())
                {
                    float val = Vector3.Distance(transform.position, r.transform.position);
                    if (val < closestWorkplaceDist && r.Capacite > 0 && agent.CalculatePath(r.transform.position, new UnityEngine.AI.NavMeshPath()))
                    {
                        closestWorkplaceDist = val;
                        ressource = r;
                    }
                }
                ressource.Capacite--;
                workplace = ressource.transform;
                if (closestWorkplaceDist != 1000f)
                    return true;
                break;


            case WorkplaceType.Rocher:
                foreach (Ressource r in FindObjectsOfType<Rocher>())
                {
                    float val = Vector3.Distance(transform.position, r.transform.position);
                    if (val < closestWorkplaceDist && r.Capacite > 0 && agent.CalculatePath(r.transform.position, new UnityEngine.AI.NavMeshPath()))
                    {
                        closestWorkplaceDist = val;
                        ressource = r;
                    }
                }
                ressource.Capacite--;
                workplace = ressource.transform;
                if (closestWorkplaceDist != 1000f)
                    return true;
                break;

        }
        
        
        return false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(ressourceStr) && (workplace.transform == collision.transform) && isGoingToWork)
        {
            isGoingToWork = false;
            StartCoroutine("Working");
        }
        print("collision");
        if (collision.transform.CompareTag("Batiment") && collision.transform.CompareTag("Batiment") == Spawn)
        {
            isReturningToSpawn = false;
        }
    }

    IEnumerator Working()
    {
        isWorking = true;
        agent.isStopped = true;
        print(workType);
        GetComponent<Animator>().SetBool(workType, true);
        yield return new WaitForSeconds(8* GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        GetComponent<Animator>().SetBool(workType, false);
        agent.isStopped = false;
        ressource.Capacite++;
        ressource = null;
        isWorking = false;
        isReturningToSpawn = true;

    }
}
