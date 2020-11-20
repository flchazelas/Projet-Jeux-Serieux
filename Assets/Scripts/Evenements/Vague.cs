using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague : Evenement
{
    public int nbEnnemis;
    public List<GameObject> listEnnemis;
    public float interval;


    // Start is called before the first frame update
    public override void Start()
    {
        Duree = (interval * nbEnnemis) * 2;
        base.Start();
        StartCoroutine("Instancie");
    }

    // Update is called once per frame
    public override void Update()
    {
        if (FindObjectsOfType<Ennemi>().Length == 0)
        {
            objectifReussi = true;
        }
    }

    IEnumerator Instancie()
    {
        while (nbEnnemis != 0 && !objectifReussi)
        {
            Instantiate(listEnnemis[0]);
            yield return new WaitForSeconds(interval);
            nbEnnemis--;
        }
    }

    public float getDuree()
    {
        return this.Duree;
    }
}