using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Variables globales du jeu
public class GameVariables : MonoBehaviour
{
    //Ressources
    public static int maxWood = 200;
    public static int maxMeat = 200;
    public static int maxGold = 200;
    public static int maxStone = 200;
    public static int maxMana = 200;
    public static int maxIron = 200;
    public static int nbIron = 100;
    public static int nbWood = 100;
    public static int nbMeat = 100;
    public static int nbGold = 100;
    public static int nbStone = 100;
    public static int nbMana = 100;
    public static int nbMaxHabitants = 20;
    //Malus et Bonus (Compris dans l'intervalle  [0,1[ )
    public static double bonus = 0.0;
    public static double malus = 0.0;

    //Timer
    public static float timer;
    public static int allowedTime = 30;
    public static int currentTime = GameVariables.allowedTime;

    //Terrain
    public static float terrainXmin = -50;
    public static float terrainXmax = 50;
    public static float terrainZmin = -50;
    public static float terrainZmax = 50;

    //Batiment
    public static Batiment batimentSelectionne;
    public static List<Batiment> listBatiment = new List<Batiment>();

    //Habitants
    public static int nbHabitants = 0;
    public static List<Habitant> listHabitant = new List<Habitant>();
    public static List<Habitant> listCombattant = new List<Habitant>();
    public static List<Habitant> listFermier = new List<Habitant>();
    public static List<Habitant> listMineur = new List<Habitant>();
    public static List<Habitant> listBucheron = new List<Habitant>();
    public static List<Habitant> listPretre = new List<Habitant>();
    public static List<Habitant> listMarchand = new List<Habitant>();
    public static List<Habitant> listHabitantAffecte = new List<Habitant>();

    public static List<Habitant> getListMetier(Batiment.role type)
    {
        if (type == Batiment.role.Combattant)
            return listCombattant;
        else if (type == Batiment.role.Fermier)
            return listFermier;
        else if (type == Batiment.role.Mineur)
            return listMineur;
        else if (type == Batiment.role.Bucheron)
            return listBucheron;
        else if (type == Batiment.role.Pretre)
            return listPretre;
        else if (type == Batiment.role.Marchand)
            return listMarchand;
        else
            return null;
    }
}
