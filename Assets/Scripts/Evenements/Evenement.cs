using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evenement : MonoBehaviour
{
    public string nom;
    public string description;
    public string type;
    public bool objectifReussi = false;
    public float duree;
    public float currentTimer = 0;

    // Start is called before the first frame update
    public virtual void Start()
    {
        nom = gameObject.name;
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    IEnumerator Timer()
    {
        print("Début : "+description+" de type "+type);
        while (currentTimer != duree && !objectifReussi)
        {
            yield return new WaitForSeconds(1);
            currentTimer++;
        }
        //objectifReussi = true;
    }

    public abstract float getDuree();
}
