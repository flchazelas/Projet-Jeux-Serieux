using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationUIUpdater : MonoBehaviour
{
    public PopulationUI avaiblePop;
    public PopulationUI foodPop;
    public PopulationUI woodPop;
    public PopulationUI goldPop;

    public void Start()
    {
        initButtonsActions();
    }

    public void Update()
    {
        foodPop.enableUpAction();
        foodPop.enableDownAction();
        updateUI();
    }

    void updateUI()
    {
        //Update Avaible Pop
        int avaiblePopCounter = getQtCurr_avaiblePop();
        avaiblePop.setPopCounter(avaiblePopCounter);

        if(avaiblePopCounter == 0)
        { //On désac les boutons + (plus de pop dispo)
            avaiblePop.disableUpAction(); foodPop.disableUpAction(); woodPop.disableUpAction(); goldPop.disableUpAction();
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
    }

    // accés modele
    public int getQtCurr_avaiblePop()
    {
        return GameVariables.listHabitant.Count;
    }
    public int getQtCurr_foodPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (bat.typeHabitant == Batiment.role.Fermier)
                count += bat.ListHabitants.Count;
        }
        return count;
    }
    public int getQtMax_foodPop()
    {
        int count = 0;

        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (bat.typeHabitant == Batiment.role.Fermier)
                count += bat.nbrMaxHab;
        }
        return count;
    }

    //Buttons actions
    void initButtonsActions()
    {
        foodPop.setUpAction(addFirstFoundHabitant_foodPop);
        foodPop.setDownAction(removeFirstFoundHabitant_foodPop);

        foodPop.enableUpAction();
        foodPop.enableDownAction();
    }
    void addFirstFoundHabitant_foodPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (bat.typeHabitant == Batiment.role.Fermier)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.Spawn.transform.position;
        villager.V = villager.Vec - villager.transform.position;
        villager.Spawn = batiment;
        GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
        GameVariables.listHabitantAffecte.Add(villager);
        batiment.ListHabitants.Add(o);
    }

    void removeFirstFoundHabitant_foodPop()
    {

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (bat.typeHabitant == Batiment.role.Fermier)
                batiment = bat; break;
        }

        if (batiment == null)
            return;
        if (batiment.ListHabitants.Count == 0)
            return;

        GameObject o = batiment.ListHabitants[0];

        if (o.GetComponent<Habitant>() == null)
            return;

        Habitant villager = o.GetComponent<Habitant>();
        batiment.ListHabitants.Remove(o);
        GameVariables.listHabitantAffecte.Remove(villager);

        villager.GetComponent<Role>().changementRole(Batiment.role.Habitant.ToString());
        GameVariables.listHabitant.Add(villager);
    }
}
