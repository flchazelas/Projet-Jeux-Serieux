using System.Collections;
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
    Text nbHabitants;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = allowTime;
        spawnHabitant();
        StartCoroutine(Timer());
        canvas = GameObject.Find("Canvas Principal");
        nbHabitants = canvas.transform.Find("Nb Habitants").GetComponent<Text>();
        

    }

    // Update is called once per frame
    void Update()
    {
        nbHabitants.text = "Nombre habitants : "+GameVariables.listHabitant.Count.ToString();
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
            GameVariables.listHabitant.Remove(clone);
            clone.Vec = new Vector3(GameVariables.batimentSelectionne.transform.position.x, 0, GameVariables.batimentSelectionne.transform.position.z);
            clone.V = clone.Vec - clone.transform.position;
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
                    GameVariables.listMarchand.Add(o.GetComponent<Bucheron>());
                    break;
                case "Pretre":
                    GameVariables.listPretre.Add(o.GetComponent<Bucheron>());
                    break;
            }

            GameVariables.batimentSelectionne.ListHabitants.Add(o);
            GameVariables.batimentSelectionne.ChangeDesc();
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
            if (!h.IsActif && h != null)
            {
                h.Vec = new Vector3(Random.Range(GameVariables.terrainXmin, GameVariables.terrainXmax), h.transform.position.y, Random.Range(GameVariables.terrainZmin, GameVariables.terrainZmax));
                h.V = h.Vec - h.transform.position;
            }
        }
    }
}
