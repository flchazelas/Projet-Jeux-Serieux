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
            avaiblePop.disableUpAction(); foodPop.disableUpAction(); woodPop.disableUpAction(); ironPop.disableUpAction(); goldPop.disableUpAction(); manaPop.disableUpAction();
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
    void addFirstFoundHabitant_miliciaPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Combattant)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.transform.position;
        villager.V = villager.Vec - villager.transform.position;
        villager.Spawn = batiment;
        GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
        GameVariables.listHabitantAffecte.Add(villager);
        batiment.ListHabitants.Add(o);
    }

    void removeFirstFoundHabitant_miliciaPop()
    {

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Combattant)
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

    //Food
    void addFirstFoundHabitant_foodPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Fermier)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.transform.position;
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
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Fermier)
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

    //Wood
    void addFirstFoundHabitant_woodPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Bucheron)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.transform.position;
        villager.V = villager.Vec - villager.transform.position;
        villager.Spawn = batiment;
        GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
        GameVariables.listHabitantAffecte.Add(villager);
        batiment.ListHabitants.Add(o);
    }

    void removeFirstFoundHabitant_woodPop()
    {

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Bucheron)
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

    //Iron
    void addFirstFoundHabitant_ironPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Mineur)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.transform.position;
        villager.V = villager.Vec - villager.transform.position;
        villager.Spawn = batiment;
        GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
        GameVariables.listHabitantAffecte.Add(villager);
        batiment.ListHabitants.Add(o);
    }

    void removeFirstFoundHabitant_ironPop()
    {

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Mineur)
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

    //Gold
    void addFirstFoundHabitant_goldPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Marchand)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.transform.position;
        villager.V = villager.Vec - villager.transform.position;
        villager.Spawn = batiment;
        GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
        GameVariables.listHabitantAffecte.Add(villager);
        batiment.ListHabitants.Add(o);
    }

    void removeFirstFoundHabitant_goldPop()
    {

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Marchand)
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

    //Mana
    void addFirstFoundHabitant_manaPop()
    {
        if (GameVariables.listHabitant.Count == 0)
            return;

        Habitant villager = GameVariables.listHabitant[0];
        GameVariables.listHabitant.Remove(villager);

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Pretre)
                batiment = bat; break;
        }

        if (batiment == null)
            return;

        villager.Vec = batiment.transform.position;
        villager.V = villager.Vec - villager.transform.position;
        villager.Spawn = batiment;
        GameObject o = villager.GetComponent<Role>().changementRole(batiment.typeHabitant.ToString());
        GameVariables.listHabitantAffecte.Add(villager);
        batiment.ListHabitants.Add(o);
    }

    void removeFirstFoundHabitant_manaPop()
    {

        Batiment batiment = null;
        foreach (Batiment bat in GameVariables.listBatiment)
        {
            if (!bat.isEnDeplacement() && bat.typeHabitant == Batiment.role.Pretre)
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
