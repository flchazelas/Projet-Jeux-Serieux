using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlacerStart : MonoBehaviour
{
    public CostPopUpUI costPopUp;

    public Button buidHouseButton;
    public Button buidMiliciaButton;
    public Button buidWoodLodgeButton;
    public Button buidFarmButton;
    public Button buidMineButton;
    public Button buidTraderButton;
    public Button buidMageButton;

    public Batiment housePrefab;
    public Batiment miliciaPrefab;
    public Batiment farmPrefab;
    public Batiment woodLodgePrefab;
    public Batiment minePrefab;
    public Batiment traderPrefab;
    public Batiment magePrefab;

    public void Start()
    {
        costPopUp.gameObject.SetActive(false);
        buidHouseButton.onClick.AddListener(() => { buildHouse(); });
        buidMiliciaButton.onClick.AddListener(() => { buildMilicia(); });
        buidFarmButton.onClick.AddListener(() => { buildFarm(); });
        buidWoodLodgeButton.onClick.AddListener(() => { buildWoodLodge(); });
        buidMineButton.onClick.AddListener(() => { buildMine(); });
        buidTraderButton.onClick.AddListener(() => { buildTrader(); });
        buidMageButton.onClick.AddListener(() => { buildMage(); });
    }
    private void buildHouse()
    {
        if (housePrefab == null)
            return;

        Batiment bat = Instantiate(housePrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }

    private void buildMilicia()
    {
        if (miliciaPrefab == null)
            return;

        Batiment bat = Instantiate(miliciaPrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }

    private void buildFarm()
    {
        if (farmPrefab == null)
            return;

        Batiment bat = Instantiate(farmPrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }
    private void buildWoodLodge()
    {
        if (woodLodgePrefab == null)
            return;

        Batiment bat = Instantiate(woodLodgePrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }
    private void buildMine()
    {
        if (minePrefab == null)
            return;

        Batiment bat = Instantiate(minePrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }
    private void buildTrader()
    {
        if (traderPrefab == null)
            return;

        Batiment bat = Instantiate(traderPrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }
    private void buildMage()
    {
        if (magePrefab == null)
            return;

        Batiment bat = Instantiate(magePrefab);
        bat.name = "Batiment " + GameVariables.listBatiment.Count;
        GameVariables.listBatiment.Add(bat);
    }

    public void buildButtonPointerEnter(Batiment batiment)
    {
        costPopUp.gameObject.SetActive(true);

        if (batiment is Entrepot)
            costPopUp.transform.SetParent(buidHouseButton.transform);
        else if (batiment is Caserne)
            costPopUp.transform.SetParent(buidMiliciaButton.transform);
        else
        {
            if(batiment.typeHabitant == Batiment.role.Bucheron)
                costPopUp.transform.SetParent(buidWoodLodgeButton.transform);
            else if (batiment.typeHabitant == Batiment.role.Fermier)
                costPopUp.transform.SetParent(buidFarmButton.transform);
            else if (batiment.typeHabitant == Batiment.role.Marchand)
                costPopUp.transform.SetParent(buidTraderButton.transform);
            else if (batiment.typeHabitant == Batiment.role.Mineur)
                costPopUp.transform.SetParent(buidMineButton.transform);
            else if (batiment.typeHabitant == Batiment.role.Pretre)
                costPopUp.transform.SetParent(buidMageButton.transform);
        }

        costPopUp.updateFoodCost(batiment.priceMeat);
        costPopUp.updateWoodCost(batiment.priceWood);
        costPopUp.updateIronCost(batiment.priceGold);
        costPopUp.updateGoldCost(batiment.priceGold);
        costPopUp.updateManaCost(batiment.priceMana);

        costPopUp.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 45);

    }

    public void buildButtonPointerExit()
    {
        costPopUp.gameObject.SetActive(false);
    }
}
