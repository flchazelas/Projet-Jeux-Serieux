using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitant : MonoBehaviour
{
    private Vector3 vec;
    private Vector3 v;
    public float speed = 1;
    private bool isActif;
    public bool isAllie;

    public Vector3 Vec { get => vec; set => vec = value; }
    public Vector3 V { get => v; set => v = value; }
    public bool IsActif { get => isActif; set => isActif = value; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Vec = new Vector3(0, 0, 0);
        V = new Vector3(0, 0, 0);
        isActif = false;
        isAllie = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (V != new Vector3(0, 0, 0))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Vec.x, transform.position.y, Vec.z), speed * Time.deltaTime);
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
    }
}
