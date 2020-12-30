using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fermier : Worker
{

    protected override void Awake()
    {
        Type = "Fermier";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        workplaceType = WorkplaceType.Champ;
        ressourceStr = "Champ";
        workType = "isFarming";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

}
