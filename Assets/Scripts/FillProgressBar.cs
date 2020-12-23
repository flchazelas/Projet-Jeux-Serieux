using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillProgressBar : MonoBehaviour
{
    private Image woodbar;
    private Image foodbar;
    private Image goldbar;
    private Image manabar;
    private Text canvasFood;
    private Text canvasGold;
    private Text canvasWood;
    private Text canvasMana;


    // Start is called before the first frame update
    void Start()
    {
        canvasFood = GameObject.Find("Nb Food").GetComponent<Text>();
        canvasGold = GameObject.Find("Nb Gold").GetComponent<Text>();
        canvasWood = GameObject.Find("Nb Wood").GetComponent<Text>();
        canvasMana = GameObject.Find("Nb Mana").GetComponent<Text>();
        manabar = GameObject.Find("ManaProgressBar").GetComponent<Image>();
        goldbar = GameObject.Find("GoldProgressBar").GetComponent<Image>();
        woodbar = GameObject.Find("WoodProgressBar").GetComponent<Image>();
        foodbar = GameObject.Find("FoodProgressBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float amountWood = (float)GameVariables.nbWood / (float)GameVariables.maxWood;
        woodbar.fillAmount = amountWood;
        float amountGold = (float)GameVariables.nbGold / (float)GameVariables.maxGold;
        goldbar.fillAmount = amountGold;
        float amountFood = (float)GameVariables.nbMeat / (float)GameVariables.maxMeat;
        foodbar.fillAmount = amountFood;
        float amountMana = (float)GameVariables.nbMana / (float)GameVariables.maxMana;
        manabar.fillAmount = amountMana;
        canvasMana.text = GameVariables.nbMana.ToString() + "/" + GameVariables.maxMana.ToString();
        canvasGold.text = GameVariables.nbGold.ToString() + "/" + GameVariables.maxGold.ToString();
        canvasWood.text = GameVariables.nbWood.ToString() + "/" + GameVariables.maxWood.ToString();
        canvasFood.text = GameVariables.nbMeat.ToString() + "/" + GameVariables.maxMeat.ToString();

    }
}
