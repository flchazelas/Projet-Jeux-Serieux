﻿using System.Collections;
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
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!isAlive())
        {
            GameVariables.listMarchand.Remove(this);
        }
        base.Update();
    }


}
