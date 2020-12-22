﻿using System.Collections;
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
        ChangeDesc();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public override void upgradeStructure()
    {
        if (batUpgrade != null && GameVariables.nbWood >= batUpgrade.GetComponent<Batiment>().priceUpgradeWood && GameVariables.nbGold >= batUpgrade.GetComponent<Batiment>().priceUpgradeGold
            && GameVariables.nbMeat >= batUpgrade.GetComponent<Batiment>().priceUpgradeMeat && GameVariables.nbMana >= batUpgrade.GetComponent<Batiment>().priceUpgradeMana)
        {
            GameVariables.nbWood -= batUpgrade.GetComponent<Batiment>().priceUpgradeWood;
            GameVariables.nbGold -= batUpgrade.GetComponent<Batiment>().priceUpgradeGold;
            GameVariables.nbMeat -= batUpgrade.GetComponent<Batiment>().priceUpgradeMeat;
            GameVariables.nbMana -= batUpgrade.GetComponent<Batiment>().priceUpgradeMana;

            desactiverCanvas();
            GameVariables.nbMaxHabitants -= habSup;
            Maison bat = batUpgrade.GetComponent<Maison>();
            habSup = bat.habSup;
            GameVariables.nbMaxHabitants += habSup;
            description = bat.description;
            nomBatiment = bat.nomBatiment;
            batName.text = nomBatiment;

            GameObject del = this.gameObject.transform.Find("Model").gameObject;
            del.name = "del";
            GameObject o = Instantiate(batUpgrade.transform.Find("Model").gameObject, this.transform);
            o.name = "Model";
            o.transform.parent = this.transform;
            GetPartModel();
            Destroy(del);
            ChangeDesc();

            batUpgrade = bat.batUpgrade;
            
            afficheCanvas();
        }
    }
     public override void ChangeDesc()
    {
        habitants.text = " ";
        batName.text = nomBatiment;
        desc.text = "Ce bâtiment permet d'accueillir " + habSup.ToString() + " habitants supplémentaires.";
        canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("NbMaxHab").GetComponent<Text>().text =" ";
    }

    void OnDestroy()
    {
        GameVariables.nbMaxHabitants -= habSup;
    }
}