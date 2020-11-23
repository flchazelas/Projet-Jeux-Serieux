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
    // Start is called before the first frame update
     override protected void Start()
    {

        base.Start();
        canGenerate = true;
    }

    // Update is called once per frame
    override protected void Update()
    {
       
        base.Update();
        nbHabitant = ListHabitants.Count;
        canvasFood = GameObject.Find("Nb Food").GetComponent<Text>();
        canvasGold = GameObject.Find("Nb Gold").GetComponent<Text>();
        canvasWood = GameObject.Find("Nb Wood").GetComponent<Text>();
        if(canGenerate) StartCoroutine("generateRessources");
    }

    IEnumerator generateRessources()
    {
        canGenerate = false;
        yield return new WaitForSeconds(nbSecondBeforeGenerate);
        canGenerate = true;
        
        if (generateGold)
        {
            GameVariables.nbGold += nbHabitant * multiplicator;
            if (GameVariables.nbGold > GameVariables.maxGold) GameVariables.nbGold = GameVariables.maxGold;
            canvasGold.text = GameVariables.nbGold.ToString();
        }
        if (generateMeat)
        {
            GameVariables.nbMeat += nbHabitant * multiplicator;
            if (GameVariables.nbMeat > GameVariables.maxMeat) GameVariables.nbMeat = GameVariables.maxMeat;
            canvasFood.text = GameVariables.nbMeat.ToString();
        }
        if (generateWood)
        {
            GameVariables.nbWood += nbHabitant * multiplicator;
            if (GameVariables.nbWood > GameVariables.maxWood) GameVariables.nbWood = GameVariables.maxWood;
            canvasWood.text = GameVariables.nbWood.ToString();
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
            description = bat.description;
            desc.text = description;
            priceUpgradeWood = bat.priceUpgradeWood;
            priceUpgradeGold = bat.priceUpgradeGold;
            priceUpgradeMeat = bat.priceUpgradeMeat;
            //print(priceUpgradeMeat);
            batUpgrade = bat.batUpgrade;


            afficheCanvas();

            /* GameObject structure = Instantiate(batUpgrade, this.transform.position, Quaternion.identity);
             structure.GetComponent<BatimentRessource>().listHabitants = listHabitants;
             desactiverCanvas();
             structure.GetComponent<BatimentRessource>().Update();
             //structure.GetComponent<BatimentRessource>().validateLocation();
             structure.GetComponent<BatimentRessource>().afficheCanvas();
             GameVariables.batimentSelectionne = structure.GetComponent<BatimentRessource>();
             Destroy(gameObject); */

        }
    }

}
