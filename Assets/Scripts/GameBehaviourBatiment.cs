using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviourBatiment : MonoBehaviour
{
    public Batiment batiment;
    Animator anim;
    Batiment clone;

    Text canvasFood;
    Text canvasGold;
    Text canvasWood;

    // Start is called before the first frame update
    void Start()
    {
        canvasFood = GameObject.Find("Nb Food").GetComponent<Text>();
        canvasGold = GameObject.Find("Nb Gold").GetComponent<Text>();
        canvasWood = GameObject.Find("Nb Wood").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasFood.text = GameVariables.nbMeat.ToString();
        canvasGold.text = GameVariables.nbGold.ToString();
        canvasWood.text = GameVariables.nbWood.ToString();
    }

    public void spawnBatiment()
    {
        clone = Instantiate(batiment);
        clone.name = "Batiment "+GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(clone);
    }
}
