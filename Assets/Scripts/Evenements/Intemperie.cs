using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intemperie : Evenement
{
    [Range(0,1)] public float bonus;
    [Range(0,1)] public float malus;

    private void Awake()
    {
        GameVariables.bonus = bonus;
        GameVariables.malus = malus;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if(currentTimer == duree - 1)
        {
            GameVariables.bonus = 1;
            GameVariables.malus = 1;
        }
    }

    public override float getDuree()
    {
        return duree;
    }
}
