using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucheron : Worker
{

    protected override void Awake()
    {
        Type = "Bucheron";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        workplaceType = WorkplaceType.Arbre;
        ressourceStr = "Arbre";
        workType = "isWoodCutting"; 
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

}
