using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combattant : Habitant
{
    private float allowedTime = 1;
    private float currentTime = 0;

    public int pointsAttaque;

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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ennemi") && currentTime == 0)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            Vec = new Vector3(Vec.x, Vec.y, Vec.z);
            V = new Vector3(0, 0, 0);
            IsActif = true;
            currentTime = allowedTime;
            GetComponent<Animator>().SetBool("isFighting", true);
            StartCoroutine("Timer", other);
        }
        else
        {
            IsActif = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            IsActif = false;
        }
    }

    public void attaquer()
    {
        GetComponent<Animator>().SetBool("isFighting", true);
        StartCoroutine("Timer");
    }

    IEnumerator Timer(Collider other)
    {
        yield return new WaitForSeconds(1);
        currentTime--;
        GetComponent<Animator>().SetBool("isFighting", false);
        if (other != null)
        {
            other.GetComponent<Combattant>().pointsVie -= pointsAttaque;
        }
    }
}
