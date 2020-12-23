using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitant : MonoBehaviour
{
    private Vector3 vec;
    private Vector3 v;
    private bool isActif;
    private string type;
    GameObject spawn;
    float tempsSurvie = 10.0f;
    float tempsConso = 5.0f;
    bool conso;

    public float speed = 1;
    public bool isAllie;
    public int pointsVie;
    public int survie = 10;
    public int quantiteConso = 1;

    public Vector3 Vec { get => vec; set => vec = value; }
    public Vector3 V { get => v; set => v = value; }
    public bool IsActif { get => isActif; set => isActif = value; }
    public string Type { get => type; set => type = value; }
    public GameObject Spawn { get => spawn; set => spawn = value; }

    private void Awake()
    {
        Type = "Habitant";
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Vec = new Vector3(0, 0, 0);
        V = new Vector3(0, 0, 0);
        isActif = false;
        isAllie = true;
        conso = true;
        StartCoroutine("Survie");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (V != new Vector3(0, 0, 0))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            //GetComponent<Rigidbody>().MovePosition(new Vector3(Vec.x, 0, Vec.z) * speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Vec.x, 0, Vec.z), speed * Time.deltaTime);
            transform.forward = V;
            if (transform.position == new Vector3(Vec.x, Vec.y, Vec.z))
            {
                V = new Vector3(0, 0, 0);
            }
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
