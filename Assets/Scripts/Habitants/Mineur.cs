using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineur : Worker
{

    protected override void Awake()
    {
        Type = "Mineur";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        workplaceType = WorkplaceType.Rocher;
        ressourceStr = "Rocher";
        workType = "isMining";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

}
