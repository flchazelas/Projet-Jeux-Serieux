using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague : Evenement
{
    public int nbEnnemis;
    public List<GameObject> listEnnemis;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        type = "Vague";
        description = "Vague d'ennemis";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
