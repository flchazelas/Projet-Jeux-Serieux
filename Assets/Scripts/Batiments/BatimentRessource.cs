using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatimentRessource : Batiment
{
    public bool generateGold;
    public bool generateMeat;
    public bool generateWood;
    public bool generateMana;
    public bool generateIron;

    public int nbSecondBeforeGenerate;
    public int multiplicator;


    private Text canvasFood;
    private Text canvasGold;
    private Text canvasWood;
    private Text canvasMana;
    private bool canGenerate;
    private int nbHabitant;
    private int nbRessourcesGenerate;
 
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        ChangeDesc();
        nbHabitant = 0;
        canGenerate = true;
    }

    // Update is called once per frame
    override public void Update()
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
        if (generateMana)
        {
            GameVariables.nbMana += nbRessourcesGenerate + (int)(nbRessourcesGenerate * GameVariables.bonus) - (int)(nbRessourcesGenerate * GameVariables.malus);
            if (GameVariables.nbMana < 0) GameVariables.nbMana = 0;
            if (GameVariables.nbMana > GameVariables.maxMana) GameVariables.nbMana = GameVariables.maxMana;
        }
        if (generateIron)
        {
            GameVariables.nbIron += nbRessourcesGenerate + (int)(nbRessourcesGenerate * GameVariables.bonus) - (int)(nbRessourcesGenerate * GameVariables.malus);
            if (GameVariables.nbIron < 0) GameVariables.nbIron = 0;
            if (GameVariables.nbIron > GameVariables.maxIron) GameVariables.nbIron = GameVariables.maxIron;
        }


    }

    public override void ChangeDesc()
    {
        batName.text = nomBatiment;
        nbHabitant = ListHabitants.Count;
        nbRessourcesGenerate = nbHabitant * multiplicator;
        habitants.text = "Nombre d'habitant affectés : " + nbHabitant.ToString();
        
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
        if (batUpgrade != null && batUpgrade.GetComponent<Batiment>().canBeConstruct() )
        {
            batUpgrade.GetComponent<Batiment>().constructBat();

            desactiverCanvas();

            BatimentRessource bat = batUpgrade.GetComponent<BatimentRessource>();
            generateMeat = bat.generateMeat;
            generateGold = bat.generateGold;
            generateWood = bat.generateWood;
            generateMana = bat.generateMana;
            multiplicator = bat.multiplicator;
            nbSecondBeforeGenerate = bat.nbSecondBeforeGenerate;
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

}
