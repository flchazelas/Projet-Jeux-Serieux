using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateResources : MonoBehaviour
{
    public bool generateGold;
    public bool generateMeat;
    public bool generateWood;
    public int multiplicator;

    private Text canvasFood;
    private Text canvasGold;
    private Text canvasWood;
    private bool canGenerate;
    private int nbHabitant;
    // Start is called before the first frame update
    void Start()
    {
        canGenerate = true;
    }

    // Update is called once per frame
    void Update()
    {
        nbHabitant = this.gameObject.GetComponent<Batiment>().ListHabitants.Count;
        canvasFood = GameObject.Find("Nb Food").GetComponent<Text>();
        canvasGold = GameObject.Find("Nb Gold").GetComponent<Text>();
        canvasWood = GameObject.Find("Nb Wood").GetComponent<Text>();
        if(canGenerate) StartCoroutine("generateRessources");
    }

    IEnumerator generateRessources()
    {
        canGenerate = false;
        yield return new WaitForSeconds(10);
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
}
