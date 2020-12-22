using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tache : Evenement
{
    private void Awake()
    {

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (tacheReussi())
        {
            objectifReussi = true;
        }
    }

    public virtual bool tacheReussi()
    {
        return false;
    }

    public override float getDuree()
    {
        return duree;
    }
}
