using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caserne : Batiment
{
    private int nbHabitant;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void upgradeStructure()
    {
        if (batUpgrade != null && batUpgrade.GetComponent<Batiment>().canBeConstruct())
        {
            batUpgrade.GetComponent<Batiment>().constructBat();

            desactiverCanvas();

            Caserne bat = batUpgrade.GetComponent<Caserne>();
            nbrMaxHab = bat.nbrMaxHab;
            description = bat.description;
            hab = bat.hab;
            nomBatiment = bat.nomBatiment;
            GameObject del = this.gameObject.transform.Find("Model").gameObject;
            del.name = "del";
            GameObject o = Instantiate(batUpgrade.transform.Find("Model").gameObject, this.transform);
            o.name = "Model";
            o.transform.parent = this.transform;
            GetPartModel();
            Destroy(del);
            batUpgrade = bat.batUpgrade;
            
            afficheCanvas();


        }
    }
}
