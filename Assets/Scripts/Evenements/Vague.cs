using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague : Evenement
{
    public int nbEnnemis;
    public List<GameObject> listEnnemis;
    public float interval;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        duree = interval * nbEnnemis;
        StartCoroutine("Instancie");
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    IEnumerator Instancie()
    {
        while(nbEnnemis != 0)
        {
            Instantiate(listEnnemis[0]);
            yield return new WaitForSeconds(interval);
            nbEnnemis--;
        }
        objectifReussi = true;
    }
}