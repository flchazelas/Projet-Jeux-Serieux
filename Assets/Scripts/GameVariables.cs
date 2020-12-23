using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Variables globales du jeu
public class GameVariables : MonoBehaviour
{
    //Ressources
    public static int maxWood = 150;
    public static int maxMeat = 100;
    public static int maxGold = 120;
    public static int maxStone = 120;
    public static int maxMana = 120;
    public static int nbWood = 100;
    public static int nbMeat = 100;
    public static int nbGold = 100;
    public static int nbStone = 100;
    public static int nbMana = 100;
    public static int nbMaxHabitants = 20;
    //Malus et Bonus (Compris dans l'intervalle  [0,1[ )
    public static double bonus = 0.6;
    public static double malus = 0.5;

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
    public static int nbHabitants = 0;
    public static List<Habitant> listHabitant = new List<Habitant>();
    public static List<Habitant> listCombattant = new List<Habitant>();
    public static List<Habitant> listFermier = new List<Habitant>();
    public static List<Habitant> listHabitantAffecte = new List<Habitant>();

}
