using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEvenements : MonoBehaviour
{
    public List<Evenement> listEvenement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Evenement getEvent()
    {
        Evenement e = listEvenement[0];
        listEvenement.Remove(e);
        return e;
    }

    public Evenement getEvent(int i)
    {
        Evenement e = listEvenement[i];
        return e;
    }

    public int getSize()
    {
        return listEvenement.Count;
    }
}
