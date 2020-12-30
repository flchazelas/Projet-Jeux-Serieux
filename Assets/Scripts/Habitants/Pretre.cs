using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pretre : Habitant
{

    protected override void Awake()
    {
        Type = "Pretre";
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!isAlive())
        {
            Destroy(random_object);
            GameVariables.listPretre.Remove(this);
        }
        base.Update();
    }
}
