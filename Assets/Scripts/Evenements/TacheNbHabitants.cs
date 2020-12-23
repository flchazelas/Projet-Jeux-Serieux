using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacheNbHabitants : Tache
{
    public enum habitant // your custom enumeration
    {
        Villageois,
        Combattant,
        Fermier,
        Mineur,
        Banquier,
        Bucheron,
        Pretre
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
            case habitant.Fermier:
                if (GameVariables.listCombattant.Count == nombreVoulu)
                    return true;
                break;
            case habitant.Mineur:
                if (GameVariables.listCombattant.Count == nombreVoulu)
                    return true;
                break;
            case habitant.Bucheron:
                if (GameVariables.listCombattant.Count == nombreVoulu)
                    return true;
                break;
            case habitant.Pretre:
                if (GameVariables.listCombattant.Count == nombreVoulu)
                    return true;
                break;
        }

        return false;
    }
}
