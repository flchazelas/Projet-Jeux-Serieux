using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caserne : Batiment
{
    private int nbHabitant;
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
        if (batUpgrade != null && batUpgrade.GetComponent<Batiment>().canBeConstruct())
        {
            GameVariables.nbWood -= batUpgrade.GetComponent<Batiment>().priceWood;
            GameVariables.nbGold -= batUpgrade.GetComponent<Batiment>().priceGold;
            GameVariables.nbMeat -= batUpgrade.GetComponent<Batiment>().priceMeat;
            GameVariables.nbMana -= batUpgrade.GetComponent<Batiment>().priceMana;

            desactiverCanvas();

            Caserne bat = batUpgrade.GetComponent<Caserne>();
            nbrMaxHab = bat.nbrMaxHab;
            description = bat.description;
            description2 = bat.description2;
            nomBatiment = bat.nomBatiment;
            batName.text = nomBatiment;
            GameObject del = this.gameObject.transform.Find("Model").gameObject;
            del.name = "del";
            GameObject o = Instantiate(batUpgrade.transform.Find("Model").gameObject, this.transform);
            o.name = "Model";
            o.transform.parent = this.transform;
            GetPartModel();
            Destroy(del);
            batUpgrade = bat.batUpgrade;

            ChangeDesc();
            afficheCanvas();


        }
    }

    public override void ChangeDesc()
    {
        batName.text = nomBatiment;
        nbHabitant = ListHabitants.Count;
        habitants.text = "Nombre d'habitant affectés : " + nbHabitant.ToString();

        canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("NbMaxHab").GetComponent<Text>().text = "Nombre maximum d'habitants : " + nbrMaxHab.ToString();
        if (nbHabitant > 0)
        {
            desc.text = description + nbHabitant.ToString() + " soldats.";
        }
        else
        {
            desc.text = "Ce bâtiment n'est pas actif, affectez lui des habitants.";
        }
    }
}
