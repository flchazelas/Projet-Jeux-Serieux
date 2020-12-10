using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviourBatiment : MonoBehaviour
{
    public Batiment batiment;
    Animator anim;
    Batiment clone;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnBatiment()
    {
        clone = Instantiate(batiment);
        clone.name = "Batiment "+GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(clone);
    }
}
