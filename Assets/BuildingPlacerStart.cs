using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlacerStart : MonoBehaviour
{
    public Button buidHouseButton;
    public Button buidWoodLodgeButton;
    public Button buidFarmButton;
    public Button buidMineButton;
    public Button buidTraderButton;

    public Batiment housePrefab;
    public Batiment farmPrefab;
    public Batiment woodLodgePrefab;
    public Batiment minePrefab;
    public Batiment traderPrefab;

    public void Start()
    {
        buidHouseButton.onClick.AddListener(() => { buildHouse(); });
        buidFarmButton.onClick.AddListener(() => { buildFarm(); });
        buidWoodLodgeButton.onClick.AddListener(() => { buildWoodLodge(); });
        buidMineButton.onClick.AddListener(() => { buildMine(); });
        buidTraderButton.onClick.AddListener(() => { buildTrader(); });
    }
    private void buildHouse()
    {
        if (housePrefab == null)
            return;

        Batiment bat = Instantiate(housePrefab);
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
}
