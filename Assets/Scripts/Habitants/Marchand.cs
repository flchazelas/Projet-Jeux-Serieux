using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marchand : Habitant
{

    protected override void Awake()
    {
        Type = "Marchand";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        Destroy(random_object);
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!isAlive())
        {
            Destroy(random_object);
            GameVariables.listMarchand.Remove(this);
        }
        base.Update();
    }


}
