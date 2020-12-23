using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Habitant"))
        {
            other.GetComponent<Habitant>().pointsVie = 0;
        }
        if (other.CompareTag("Ennemi"))
        {
            other.GetComponent<Ennemi>().pointsVie = 0;
        }
    }
}
