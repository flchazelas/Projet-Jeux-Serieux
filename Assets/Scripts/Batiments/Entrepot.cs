using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrepot : Batiment
{
    public int resSup;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        GameVariables.maxGold += resSup;
        GameVariables.maxMeat += resSup;
        GameVariables.maxWood += resSup;
        GameVariables.maxMana += resSup;
        GameVariables.maxIron += resSup;
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
            OnDestroy();
            Entrepot bat = batUpgrade.GetComponent<Entrepot>();
            resSup = bat.resSup;
            GameVariables.maxGold += resSup;
            GameVariables.maxMeat += resSup;
            GameVariables.maxWood += resSup;
            GameVariables.maxMana += resSup;
            GameVariables.maxIron += resSup;
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
        GameVariables.maxGold -= resSup;
        GameVariables.maxMeat -= resSup;
        GameVariables.maxWood -= resSup;
        GameVariables.maxMana -= resSup;
        GameVariables.maxIron -= resSup;
    }
}
