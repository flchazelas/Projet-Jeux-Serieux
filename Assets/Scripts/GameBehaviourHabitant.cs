﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviourHabitant : MonoBehaviour
{
    public Habitant habitant;
    Animator anim;
    Habitant clone;
    float allowTime = 10.0f;
    float currentTime;
    bool b = true;

    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = allowTime;
        spawnHabitant();
        StartCoroutine(Timer());
        canvas = GameObject.Find("Canvas Principal");


    }

    // Update is called once per frame
    void Update()
    {
        if (!b)
        {
            walk();
            b = true;
            currentTime = allowTime;
            StartCoroutine(Timer());
        }
    }

    public void spawnHabitant()
    {
        clone = Instantiate(habitant, new Vector3(0, 0, 0), Quaternion.identity);
        GameVariables.listHabitant.Add(clone);
        GameVariables.nbHabitants++;
    }

    public void affectation()
    {
        if (GameVariables.listHabitant.Count != 0 && GameVariables.batimentSelectionne.ListHabitants.Count < GameVariables.batimentSelectionne.nbrMaxHab )
        {
            clone = GameVariables.listHabitant[0];
            clone.random_object.SetActive(false);
            Destroy(clone.random_object);
            GameVariables.listHabitant.Remove(clone);
            clone.Spawn = GameVariables.batimentSelectionne;
            GameObject o = clone.GetComponent<Role>().changementRole(GameVariables.batimentSelectionne.typeHabitant.ToString());
            GameVariables.listHabitantAffecte.Add(clone);

            switch (GameVariables.batimentSelectionne.typeHabitant.ToString())
            {
                case "Combattant":
                    GameVariables.listCombattant.Add(o.GetComponent<Combattant>());
                    break;

                case "Fermier":
                    GameVariables.listFermier.Add(o.GetComponent<Fermier>());
                    break;

                case "Mineur":
                    GameVariables.listMineur.Add(o.GetComponent<Mineur>());
                    break;
                case "Bucheron":
                    GameVariables.listBucheron.Add(o.GetComponent<Bucheron>());
                    break;
                case "Marchand":
                    print("New Marchand");
                    GameVariables.listMarchand.Add(o.GetComponent<Marchand>());
                    break;
                case "Pretre":
                    GameVariables.listPretre.Add(o.GetComponent<Pretre>());
                    break;
            }

            GameVariables.batimentSelectionne.ListHabitants.Add(o);
        }
    }

    IEnumerator Timer()
    {
        while(currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            currentTime--;
        }
        b = false;
    }

    public void walk()
    {
        foreach (Habitant h in FindObjectsOfType<Habitant>())
        {
            if (h.random_object!=null && !h.IsActif && h != null)
            {
                
                h.random_object.transform.position = new Vector3(Random.Range(GameVariables.terrainXmin, GameVariables.terrainXmax), h.transform.position.y, Random.Range(GameVariables.terrainZmin, GameVariables.terrainZmax));
                //h.V = h.Vec - h.transform.position;
            }
        }
    }

    public void ConvertVillagerFromTypeToType(string baseType, string targetType)
    {
        //Pick base collection

    }
}
