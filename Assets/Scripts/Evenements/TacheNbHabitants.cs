using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacheNbHabitants : Tache
{
    public enum habitant // your custom enumeration
    {
        Villageois,
        Combattant
    };
    public habitant typeHabitant;
    public int nombreVoulu;


    public override bool tacheReussi()
    {
        switch (typeHabitant)
        {
            case habitant.Villageois:
                if (GameVariables.listHabitant.Count == nombreVoulu)
                    return true;
                break;
            case habitant.Combattant:
                if (GameVariables.listCombattant.Count == nombreVoulu)
                    return true;
                break;
        }

        return false;
    }
}
