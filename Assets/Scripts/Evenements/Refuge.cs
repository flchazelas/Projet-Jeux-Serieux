using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuge : Evenement
{
    [Range(1, 10)] public int nbRefugies;

    public Habitant h;

    private void Awake()
    {
        for (int i = 0; i < nbRefugies; i++)
        {
            Habitant habitant = Instantiate(h);
            GameVariables.listHabitant.Add(habitant);
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {

    }
}
