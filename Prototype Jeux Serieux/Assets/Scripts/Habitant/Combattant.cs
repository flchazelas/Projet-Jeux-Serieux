using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combattant : Habitant
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isFighting", true);
            Vec = new Vector3(Vec.x, Vec.y, Vec.z);
            V = other.transform.position;
        }
    }
}
