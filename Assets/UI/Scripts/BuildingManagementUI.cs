using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingManagementUI : MonoBehaviour
{
    private bool isMenuOpen;

    //Editor Properties
    public TMP_Text titleText;
    public TMP_Text descText;

    public PopulationUI buildingPopulationManager;
    public BuildingProductionUI buildingProdUI;
    public BuildingUpgradeUI buildingUpgradeUI;

    public TMP_Text firstSeparator;
    public TMP_Text secondSeparator;
    public TMP_Text thirdSeparator;

    public Button closeButton;

    //Singleton
    private static BuildingManagementUI instance;
    public static BuildingManagementUI getInstance() { return instance; }

    //Lifetime Functions
    void Awake()
    {
        if (instance == null)
            instance = this;

        GameVariables.batimentSelectionne = null;
        isMenuOpen = false;
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        closeButton.onClick.AddListener(closeBuildingManagement);
    }

    void Update()
    {
        if (this.isOpen())
            this.updateUI();
    }

    //Private Functions
    private void initUI()
    {
        //Set Title Text
        titleText.text = GameVariables.batimentSelectionne.nomBatiment;
        //Set Desc Text
        descText.text = GameVariables.batimentSelectionne.description;
        descText.text += "\n" + GameVariables.batimentSelectionne.description;

        //Check Effectifs UI Needed + Set Pop Manager Actions
        if (GameVariables.batimentSelectionne.nbrMaxHab != 0)
        {
            buildingPopulationManager.gameObject.SetActive(true);
            buildingPopulationManager.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            secondSeparator.gameObject.SetActive(true);
            secondSeparator.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            buildingPopulationManager.setUpAction(() => {
                if (GameVariables.listHabitant.Count == 0)
                    return;

                Batiment batiment = GameVariables.batimentSelectionne;
                if (batiment == null || batiment.isEnDeplacement() || batiment.ListHabitants.Count >= batiment.nbrMaxHab)
                    return;

                List<Habitant> listMetierBat = GameVariables.getListMetier(batiment.typeHabitant);
                if (listMetierBat == null)
                    return;

                Habitant villager = GameVariables.listHabitant[0];
                GameVariables.listHabitant.Remove(villager);
                
                villager.Spawn = batiment;
                GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
                GameVariables.listHabitantAffecte.Add(villager);
                listMetierBat.Add(villager);
                batiment.ListHabitants.Add(o);
            });

            buildingPopulationManager.setDownAction(() => {
                Batiment batiment = GameVariables.batimentSelectionne;
                if (batiment == null || batiment.isEnDeplacement())
                    return;
                if (batiment.ListHabitants.Count == 0)
                    return;

                GameObject o = batiment.ListHabitants[0];

                if (o.GetComponent<Habitant>() == null)
                    return;

                List<Habitant> listMetierBat = GameVariables.getListMetier(batiment.typeHabitant);
                if (listMetierBat == null)
                    return;

                Habitant villager = o.GetComponent<Habitant>();
                batiment.ListHabitants.Remove(o);
                listMetierBat.Remove(villager);
                GameVariables.listHabitantAffecte.Remove(villager);

                villager.GetComponent<Role>().changementRole(Batiment.role.Habitant.ToString());
                GameVariables.listHabitant.Add(villager);
            });
        }
        else
        {
            buildingPopulationManager.gameObject.SetActive(false);
            buildingPopulationManager.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            secondSeparator.gameObject.SetActive(false);
            secondSeparator.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }

        //Check Prod UI Needed
        if (GameVariables.batimentSelectionne is BatimentRessource)
        {
            buildingProdUI.gameObject.SetActive(true);
            buildingProdUI.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            thirdSeparator.gameObject.SetActive(true);
            thirdSeparator.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        else
        {
            buildingProdUI.gameObject.SetActive(false);
            buildingProdUI.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            thirdSeparator.gameObject.SetActive(false);
            thirdSeparator.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }

        //Check Upgrade UI Needed + Set Upgrade Action
        if (GameVariables.batimentSelectionne.batUpgrade != null)
        {
            buildingUpgradeUI.gameObject.SetActive(true);
            buildingUpgradeUI.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            buildingUpgradeUI.setUpgradeAction(() => {
                GameVariables.batimentSelectionne.upgradeStructure();
            });
        }
        else
        {
            buildingUpgradeUI.gameObject.SetActive(false);
            buildingUpgradeUI.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
    }

    private void updateUI()
    {
        if (titleText.text != GameVariables.batimentSelectionne.nomBatiment)
            initUI();

        //Update Effectifs if Nessecary
        if (buildingPopulationManager.gameObject.activeSelf == true)
        {
            buildingPopulationManager.enableUpAction();
            buildingPopulationManager.enableDownAction();

            //Update Avaible Pop
            int avaiblePopCounter = GameVariables.listHabitant.Count;

            if (avaiblePopCounter == 0)
            { //On désac le bouton + (plus de pop dispo)
                buildingPopulationManager.disableUpAction(); 
            }

            //Update Bat Pop
            int batPopCounter = GameVariables.batimentSelectionne.ListHabitants.Count;
            buildingPopulationManager.setPopCounter(batPopCounter);
            if (batPopCounter == 0)
            { //On désac le bouton - (pas de pop a retirer)
                buildingPopulationManager.disableDownAction();
            }
            if (batPopCounter == GameVariables.batimentSelectionne.nbrMaxHab)
            { //On désac le bouton + (plus de place pour pop supp)
                buildingPopulationManager.disableUpAction();
            }
        }

        //Update Prod if Nessecary
        if (buildingProdUI.gameObject.activeSelf == true)
        {
            buildingProdUI.updateProdIcon((GameVariables.batimentSelectionne as BatimentRessource).typeHabitant);
            buildingProdUI.updateCurrentProd((GameVariables.batimentSelectionne as BatimentRessource).getCurrentResourceProd());
            buildingProdUI.updateProdUnit((GameVariables.batimentSelectionne as BatimentRessource).nbSecondBeforeGenerate, "sec");
        }

        //Update Upgrade if Nessecary
        if (buildingUpgradeUI.gameObject.activeSelf == true)
        {
            //MAJ des couts d'upgrade
            buildingUpgradeUI.updateFoodCost(GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceMeat);
            buildingUpgradeUI.updateWoodCost(GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceWood);
            buildingUpgradeUI.updateIronCost(GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceIron);
            buildingUpgradeUI.updateGoldCost(GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceGold);
            buildingUpgradeUI.updateManaCost(GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceMana);


            buildingUpgradeUI.setUpgradeButtonActive(true); //De base upgrade possible
            if (GameVariables.nbMeat < GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceMeat
             || GameVariables.nbWood < GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceWood
             || GameVariables.nbIron < GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceIron
             || GameVariables.nbGold < GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceGold
             || GameVariables.nbMana < GameVariables.batimentSelectionne.batUpgrade.GetComponent<Batiment>().priceMana)
            { //Si une ressource manquante
                buildingUpgradeUI.setUpgradeButtonActive(false); //Upgrade imposible
            }
        }
    }

    //Public Interface
    public bool isOpen() { return isMenuOpen; }

    public void openBuildingManagement(Batiment bat)
    {
        if (this.isOpen())
            return;

        GameVariables.batimentSelectionne = bat;
        isMenuOpen = true;
        initUI();
        this.gameObject.SetActive(true);

    }

    public void closeBuildingManagement()
    {
        if (!this.isOpen())
            return;

        GameVariables.batimentSelectionne = null;
        isMenuOpen = false;
        this.gameObject.SetActive(false);
    }
}