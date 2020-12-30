using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maison : Batiment
{
    public int habSup;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        GameVariables.nbMaxHabitants += habSup;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public override void upgradeStructure()
    {
        if (batUpgrade != null && batUpgrade.GetComponent<Batiment>().canBeConstruct())
        {
            batUpgrade.GetComponent<Batiment>().constructBat();

            desactiverCanvas();
            GameVariables.nbMaxHabitants -= habSup;
            Maison bat = batUpgrade.GetComponent<Maison>();
            habSup = bat.habSup;
            GameVariables.nbMaxHabitants += habSup;
            description = bat.description;
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

    void OnDestroy()
    {
        GameVariables.nbMaxHabitants -= habSup;
    }
}
