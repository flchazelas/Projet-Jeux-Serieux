using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Variables globales du jeu
public class GameVariables : MonoBehaviour
{
    public static int allowedTime = 30;
    public static int currentTime = GameVariables.allowedTime;
    public static float terrainXmin = -50;
    public static float terrainXmax = 50;
    public static float terrainZmin = -50;
    public static float terrainZmax = 50;
    public static Batiment batimentSelectionne;

    public static List<Habitant> listHabitant = new List<Habitant>();
    public static List<Habitant> listHabitantAffecte = new List<Habitant>();
    public static List<Batiment> listBatiment = new List<Batiment>();
}
