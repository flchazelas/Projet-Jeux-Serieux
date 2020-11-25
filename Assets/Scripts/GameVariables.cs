using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Variables globales du jeu
public class GameVariables : MonoBehaviour
{
    //Ressources
    public static int maxWood = 3000;
    public static int maxMeat = 1000;
    public static int maxGold = 6000;
    public static int nbWood = 0;
    public static int nbMeat = 0;
    public static int nbGold = 0;
    //Malus et Bonus 
    public static float bonus = 1;
    public static float malus = 1;

    //Timer
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
    public static List<Habitant> listHabitant = new List<Habitant>();
    public static List<Combattant> listCombattant = new List<Combattant>();
    public static List<Habitant> listHabitantAffecte = new List<Habitant>();
}
