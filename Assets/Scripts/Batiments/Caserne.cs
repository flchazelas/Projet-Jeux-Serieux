﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caserne : Batiment
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void upgradeStructure()
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeDesc()
    {
        throw new System.NotImplementedException();
    }
}
