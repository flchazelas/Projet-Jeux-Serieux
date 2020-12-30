using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostPopUpUI : MonoBehaviour
{
    public UpgradeCostUI foodCost;
    public UpgradeCostUI woodCost;
    public UpgradeCostUI ironCost;
    public UpgradeCostUI goldCost;
    public UpgradeCostUI manaCost;

    public void updateFoodCost(int foodCostValue)
    {
        if (foodCostValue <= 0)
        {
            this.foodCost.gameObject.SetActive(false);
            this.foodCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.foodCost.gameObject.SetActive(true);
            this.foodCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.foodCost.updateCurrentProd(foodCostValue);
        }
    }

    public void updateWoodCost(int woodCostValue)
    {
        if (woodCostValue <= 0)
        {
            this.woodCost.gameObject.SetActive(false);
            this.woodCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.woodCost.gameObject.SetActive(true);
            this.woodCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.woodCost.updateCurrentProd(woodCostValue);
        }
    }

    public void updateIronCost(int ironCostValue)
    {
        if (ironCostValue <= 0)
        {
            this.ironCost.gameObject.SetActive(false);
            this.ironCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.ironCost.gameObject.SetActive(true);
            this.ironCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.ironCost.updateCurrentProd(ironCostValue);
        }
    }

    public void updateGoldCost(int goldCostValue)
    {
        if (goldCostValue <= 0)
        {
            this.goldCost.gameObject.SetActive(false);
            this.goldCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.goldCost.gameObject.SetActive(true);
            this.goldCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.goldCost.updateCurrentProd(goldCostValue);
        }
    }

    public void updateManaCost(int manaCostValue)
    {
        if (manaCostValue <= 0)
        {
            this.manaCost.gameObject.SetActive(false);
            this.manaCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.manaCost.gameObject.SetActive(true);
            this.manaCost.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.manaCost.updateCurrentProd(manaCostValue);
        }
    }
}
