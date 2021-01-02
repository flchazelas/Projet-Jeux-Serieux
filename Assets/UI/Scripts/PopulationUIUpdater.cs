using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationUIUpdater : MonoBehaviour
{
    public PopulationUI avaiblePop;
    public PopulationUI miliciaPop;
    public PopulationUI foodPop;
    public PopulationUI woodPop;
    public PopulationUI ironPop;
    public PopulationUI goldPop;
    public PopulationUI manaPop;

    public void Start()
    {
        initButtonsActions();
    }

    public void Update()
    {
        miliciaPop.enableUpAction();
        miliciaPop.enableDownAction();
        foodPop.enableUpAction();
        foodPop.enableDownAction();
        woodPop.enableUpAction();
        woodPop.enableDownAction();
        ironPop.enableUpAction();
        ironPop.enableDownAction();
        goldPop.enableUpAction();
        goldPop.enableDownAction();
        manaPop.enableUpAction();
        manaPop.enableDownAction();
        updateUI();
    }

    void updateUI()
    {
        //Update Avaible Pop
        int avaiblePopCounter = getQtCurr_avaiblePop();
        avaiblePop.setPopCounter(avaiblePopCounter);

        if(avaiblePopCounter == 0)
        { //On désac les boutons + (plus de pop dispo)
            avaiblePop.disableUpAction(); miliciaPop.disableUpAction(); foodPop.disableUpAction(); woodPop.disableUpAction(); ironPop.disableUpAction(); goldPop.disableUpAction(); manaPop.disableUpAction();
        }

        //Update Food Pop
        int miliciaPopCounter = getQtCurr_miliciaPop();
        miliciaPop.setPopCounter(miliciaPopCounter);
        if (miliciaPopCounter == 0)
        { //On désac le bouton - (pas de pop a retirer)
            miliciaPop.disableDownAction();
        }
        if (miliciaPopCounter == getQtMax_miliciaPop())
        { //On désac le bouton + (plus de place pour pop supp)
            miliciaPop.disableUpAction();
        }

        //Update Food Pop
        int foodPopCounter = getQtCurr_foodPop();
        foodPop.setPopCounter(foodPopCounter);
        if (foodPopCounter == 0)
        { //On désac le bouton - (pas de pop a retirer)
            foodPop.disableDownAction();
        }
        if (foodPopCounter == getQtMax_foodPop())
        { //On désac le bouton + (plus de place pour pop supp)
            foodPop.disableUpAction();
        }

        //Update Wood Pop
        int woodPopCounter = getQtCurr_woodPop();
        woodPop.setPopCounter(woodPopCounter);
        if (woodPopCounter == 0)
        { //On désac le bouton - (pas de pop a retirer)
            woodPop.disableDownAction();
        }
        if (woodPopCounter == getQtMax_woodPop())
        { //On désac le bouton + (plus de place pour pop supp)
            woodPop.disableUpAction();
        }

        //Update Iron Pop
        int ironPopCounter = getQtCurr_ironPop();
        ironPop.setPopCounter(ironPopCounter);
        if (ironPopCounter == 0)
        { //On désac le bouton - (pas de pop a retirer)
            ironPop.disableDownAction();
        }
        if (ironPopCounter == getQtMax_ironPop())
        { //On désac le bouton + (plus de place pour pop supp)
            ironPop.disableUpAction();
        }

        //Update Gold Pop
        int goldPopCounter = getQtCurr_goldPop();
        goldPop.setPopCounter(goldPopCounter);
        if (goldPopCounter == 0)
        { //On désac le bouton - (pas de pop a retirer)
            goldPop.disableDownAction();
        }
        if (goldPopCounter == getQtMax_goldPop())
        { //On désac le bouton + (plus de place pour pop supp)
            goldPop.disableUpAction();
        }

        //Update Mana Pop
        int manaPopCounter = getQtCurr_manaPop();
        manaPop.setPopCounter(manaPopCounter);
        if (manaPopCounter == 0)
        { //On désac le bouton - (pas de pop a retirer)
            manaPop.disableDownAction();
        }
        if (manaPopCounter == getQtMax_manaPop())
        { //On désac le bouton + (plus de place pour pop supp)
            manaPop.disableUpAction();
        }
    }

    // accés modele
    public int getQtCurr_avaiblePop()
    {
        return GameVariables.listHabitant.Count;
    }

        //Food
    public int getQtCurr_miliciaPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Combattant)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_miliciaPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Combattant)
                count += bat.nbrMaxHab;
        }
        return count;
    }

    //Food
    public int getQtCurr_foodPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Fermier)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_foodPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Fermier)
                count += bat.nbrMaxHab;
        }
        return count;
    }

        //Wood
    public int getQtCurr_woodPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Bucheron)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_woodPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Bucheron)
                count += bat.nbrMaxHab;
        }
        return count;
    }

        //Iron
    public int getQtCurr_ironPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Mineur)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_ironPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Mineur)
                count += bat.nbrMaxHab;
        }
        return count;
    }

        //Gold
    public int getQtCurr_goldPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Marchand)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_goldPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Marchand)
                count += bat.nbrMaxHab;
        }
        return count;
    }

        //Mana
    public int getQtCurr_manaPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Pretre)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_manaPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Pretre)
                count += bat.nbrMaxHab;
        }
        return count;
    }

    //Buttons actions
    void initButtonsActions()
    {
        miliciaPop.setUpAction(addFirstFoundHabitant_miliciaPop);
        miliciaPop.setDownAction(removeFirstFoundHabitant_miliciaPop);
        miliciaPop.enableUpAction();
        miliciaPop.enableDownAction();

        foodPop.setUpAction(addFirstFoundHabitant_foodPop);
        foodPop.setDownAction(removeFirstFoundHabitant_foodPop);
        foodPop.enableUpAction();
        foodPop.enableDownAction();

        woodPop.setUpAction(addFirstFoundHabitant_woodPop);
        woodPop.setDownAction(removeFirstFoundHabitant_woodPop);
        woodPop.enableUpAction();
        woodPop.enableDownAction();

        ironPop.setUpAction(addFirstFoundHabitant_ironPop);
        ironPop.setDownAction(removeFirstFoundHabitant_ironPop);
        ironPop.enableUpAction();
        ironPop.enableDownAction();

        goldPop.setUpAction(addFirstFoundHabitant_goldPop);
        goldPop.setDownAction(removeFirstFoundHabitant_goldPop);
        goldPop.enableUpAction();
        goldPop.enableDownAction();

        manaPop.setUpAction(addFirstFoundHabitant_manaPop);
        manaPop.setDownAction(removeFirstFoundHabitant_manaPop);
        manaPop.enableUpAction();
        manaPop.enableDownAction();
    }

    //Milicia
    void addFirstFoundHabitantForType(Batiment.role type)
    {
        if (GameVariables.listHabitant.Count == 0 && GameVariables.batimentSelectionne.ListHabitants.Count < GameVariables.batimentSelectionne.nbrMaxHab)
            return;


        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == type && bat.ListHabitants.Count < bat.nbrMaxHab)
            {
                batiment = bat;
                break;
            }
        }

        if (batiment == null || batiment.ListHabitants.Count >= batiment.nbrMaxHab)
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
    }

    void removeFirstFoundHabitantForType(Batiment.role type)
    {
        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == type && bat.ListHabitants.Count > 0)
            {
                Debug.Log(batiment);
                batiment = bat; break;
            }
        }

        if (batiment == null || batiment.ListHabitants.Count <= 0)
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
    }

    void addFirstFoundHabitant_miliciaPop()
    {
        addFirstFoundHabitantForType(Batiment.role.Combattant);
    }

    void removeFirstFoundHabitant_miliciaPop()
    {
        removeFirstFoundHabitantForType(Batiment.role.Combattant);
    }

    //Food
    void addFirstFoundHabitant_foodPop()
    {
        addFirstFoundHabitantForType(Batiment.role.Fermier);
    }

    void removeFirstFoundHabitant_foodPop()
    {
        removeFirstFoundHabitantForType(Batiment.role.Fermier);
    }

    //Wood
    void addFirstFoundHabitant_woodPop()
    {
        addFirstFoundHabitantForType(Batiment.role.Bucheron);
    }

    void removeFirstFoundHabitant_woodPop()
    {
        removeFirstFoundHabitantForType(Batiment.role.Bucheron);
    }

    //Iron
    void addFirstFoundHabitant_ironPop()
    {
        addFirstFoundHabitantForType(Batiment.role.Mineur);
    }

    void removeFirstFoundHabitant_ironPop()
    {
        removeFirstFoundHabitantForType(Batiment.role.Mineur);
    }

    //Gold
    void addFirstFoundHabitant_goldPop()
    {
        addFirstFoundHabitantForType(Batiment.role.Marchand);
    }

    void removeFirstFoundHabitant_goldPop()
    {
        removeFirstFoundHabitantForType(Batiment.role.Marchand);
    }

    //Mana
    void addFirstFoundHabitant_manaPop()
    {
        addFirstFoundHabitantForType(Batiment.role.Pretre);
    }

    void removeFirstFoundHabitant_manaPop()
    {
        removeFirstFoundHabitantForType(Batiment.role.Pretre);
    }
}
