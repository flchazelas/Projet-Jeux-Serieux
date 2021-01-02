using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Habitant : MonoBehaviour
{
    private bool isActif;
    private string type;
    public GameObject random_object;
    Batiment spawn;
    float tempsSurvie = 10.0f;
    float tempsConso = 5.0f;
    bool conso;

    public Transform target;
    protected NavMeshAgent agent;

    public float speed = 1;
    public bool isAllie;
    public int pointsVie;
    public int survie = 10;
    public int quantiteConso = 1;

    public bool IsActif { get => isActif; set => isActif = value; }
    public string Type { get => type; set => type = value; }
    public Batiment Spawn { get => spawn; set => spawn = value; }

    protected virtual void Awake()
    {
        Type = "Habitant";
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        random_object = new GameObject();random_object.transform.position= new Vector3(Random.Range(GameVariables.terrainXmin, GameVariables.terrainXmax), 0, Random.Range(GameVariables.terrainZmin, GameVariables.terrainZmax));

        target = random_object.transform;
        isActif = false;
        isAllie = true;
        conso = true;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine("Survie");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(target!=null)
            agent.SetDestination(target.position);


        if (agent.velocity.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        if (!isAlive())
        {
            GameVariables.listHabitant.Remove(this);
            GameVariables.nbHabitants--;
            Destroy(gameObject);
        }

        if (conso)
        {
            StartCoroutine("Consomme");
        }
    }

    public bool isAlive()
    {
        if(pointsVie <= 0 || survie == 0)
            return false;
        else
            return true;
    }

    IEnumerator Consomme()
    {
        if(GameVariables.nbMeat > 0 && survie != 10)
        {
            conso = false;
            yield return new WaitForSeconds(tempsConso);
            GameVariables.nbMeat -= quantiteConso;
            survie++;
            //print("consomme");
            conso = true;
        }
    }

    IEnumerator Survie()
    {
        while(survie != 0)
        {
            yield return new WaitForSeconds(tempsSurvie);
            //print("survie");
            survie--;
        }
    }
}
