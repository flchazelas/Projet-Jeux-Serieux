using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitant : MonoBehaviour
{
    private Vector3 vec;
    private Vector3 v;
    private bool isActif;
    private string type;

    public float speed = 1;
    public bool isAllie;
    public int pointsVie;

    public Vector3 Vec { get => vec; set => vec = value; }
    public Vector3 V { get => v; set => v = value; }
    public bool IsActif { get => isActif; set => isActif = value; }
    public string Type { get => type; set => type = value; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Vec = new Vector3(0, 0, 0);
        V = new Vector3(0, 0, 0);
        isActif = false;
        isAllie = true;
        Type = "Villageois";
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (V != new Vector3(0, 0, 0))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Vec.x, Vec.y, Vec.z), speed * Time.deltaTime);
            transform.forward = V;
            if(transform.position == new Vector3(Vec.x, transform.position.y, Vec.z))
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
            Destroy(gameObject);
        }
    }

    public bool isAlive()
    {
        if(pointsVie <= 0)
            return false;
        else
            return true;
    }
}
