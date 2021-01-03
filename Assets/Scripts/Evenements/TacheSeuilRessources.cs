using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacheSeuilRessources : Tache
{
    public enum habitant // your custom enumeration
    {
        Gold,
        Meat,
        Wood,
        Stone
    };
    public habitant typeRessource;
    public int nombreVoulu;


    public override bool tacheReussi()
    {
        switch (typeRessource)
        {
            case habitant.Gold:
                if (GameVariables.nbGold >= nombreVoulu)
                    return true;
                break;
            case habitant.Meat:
                if (GameVariables.nbMeat >= nombreVoulu)
                    return true;
                break;
            case habitant.Wood:
                if (GameVariables.nbWood >= nombreVoulu)
                    return true;
                break;
            case habitant.Stone:
                if (GameVariables.nbStone >= nombreVoulu)
                    return true;
                break;
        }

        return false;
    }
}
