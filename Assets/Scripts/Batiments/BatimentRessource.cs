using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatimentRessource : Batiment
{
    public bool generateGold;
    public bool generateMeat;
    public bool generateWood;

    public int nbSecondBeforeGenerate;
    public int multiplicator;


    private Text canvasFood;
    private Text canvasGold;
    private Text canvasWood;
    private bool canGenerate;
    private int nbHabitant;
    private int nbRessourcesGenerate;
 
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        ChangeDesc();
        nbHabitant = 0;
        canGenerate = true;
    }

    // Update is called once per frame
    override protected void Update()
    {

        base.Update();
        nbHabitant = ListHabitants.Count;
        if (canGenerate) StartCoroutine("generateRessources");
    }

    IEnumerator generateRessources()
    {
        canGenerate = false;
        yield return new WaitForSeconds(nbSecondBeforeGenerate);
        canGenerate = true;
        if (generateGold)
        {
            
            GameVariables.nbGold += nbRessourcesGenerate + (int)(nbRessourcesGenerate * GameVariables.bonus) - (int)(nbRessourcesGenerate * GameVariables.malus);
            if (GameVariables.nbGold < 0) GameVariables.nbGold = 0;
            if (GameVariables.nbGold > GameVariables.maxGold) GameVariables.nbGold = GameVariables.maxGold;
        }
        if (generateMeat)
        {
            GameVariables.nbMeat += nbRessourcesGenerate + (int)(nbRessourcesGenerate * GameVariables.bonus) - (int)(nbRessourcesGenerate * GameVariables.malus);
            if (GameVariables.nbMeat < 0) GameVariables.nbMeat = 0;
            if (GameVariables.nbMeat > GameVariables.maxMeat) GameVariables.nbMeat = GameVariables.maxMeat;
        }
        if (generateWood)
        {
            GameVariables.nbWood += nbRessourcesGenerate + (int)(nbRessourcesGenerate * GameVariables.bonus) - (int)(nbRessourcesGenerate * GameVariables.malus);
            if (GameVariables.nbWood < 0) GameVariables.nbWood = 0;
            if (GameVariables.nbWood > GameVariables.maxWood) GameVariables.nbWood = GameVariables.maxWood;
        }


    }

    public override void ChangeDesc()
    {
        batName.text = nomBatiment;
        nbHabitant = ListHabitants.Count;
        nbRessourcesGenerate = nbHabitant * multiplicator;
        canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("NbMaxHab").GetComponent<Text>().text = "Nombre maximum d'habitants : " + nbrMaxHab.ToString();
        if (nbHabitant > 0)
        {
            desc.text = description + (nbRessourcesGenerate + (int)(nbRessourcesGenerate * GameVariables.bonus) - (int)(nbRessourcesGenerate * GameVariables.malus)).ToString() + description2 + nbSecondBeforeGenerate.ToString() + " secondes";
        }
        else
        {
            desc.text = "Ce bâtiment n'est pas actif, affectez lui de la main d'oeuvre.";
        }
    }
    public override void upgradeStructure()
    {
        if (GameVariables.nbWood >= priceUpgradeWood && GameVariables.nbGold >= priceUpgradeGold && GameVariables.nbMeat >= priceUpgradeMeat && batUpgrade != null)
        {
            GameVariables.nbWood -= priceUpgradeWood;
            GameVariables.nbGold -= priceUpgradeGold;
            GameVariables.nbMeat -= priceUpgradeMeat;

            desactiverCanvas();

            BatimentRessource bat = batUpgrade.GetComponent<BatimentRessource>();
            generateMeat = bat.generateMeat;
            generateGold = bat.generateGold;
            generateWood = bat.generateWood;
            multiplicator = bat.multiplicator;
            nbSecondBeforeGenerate = bat.nbSecondBeforeGenerate;
            nbrMaxHab = bat.nbrMaxHab;
            description = bat.description;
            description2 = bat.description2;
            nomBatiment = bat.nomBatiment;
            batName.text = nomBatiment;
            
            priceUpgradeWood = bat.priceUpgradeWood;
            priceUpgradeGold = bat.priceUpgradeGold;
            priceUpgradeMeat = bat.priceUpgradeMeat;
            GameObject del = this.gameObject.transform.Find("Model").gameObject;
            del.name = "del";
            GameObject o = Instantiate(batUpgrade.transform.Find("Model").gameObject, this.transform);
            o.name = "Model";
            o.transform.parent = this.transform;
            GetPartModel();
            batUpgrade = bat.batUpgrade;
            Destroy(del);
            ChangeDesc();
            afficheCanvas();
            

        }
    }

}
