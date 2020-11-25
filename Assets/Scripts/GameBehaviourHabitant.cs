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
    }

    public void affectation()
    {
        if (GameVariables.listHabitant.Count != 0)
        {
            clone = GameVariables.listHabitant[0];
            GameVariables.listHabitant.Remove(clone);
            GameVariables.listHabitantAffecte.Add(clone);
            GameVariables.batimentSelectionne.ListHabitants.Add(clone);
            clone.Vec = GameVariables.batimentSelectionne.transform.position;
            clone.V = clone.Vec - clone.transform.position;
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
        foreach (Habitant h in GameVariables.listHabitant)
        {
            if (!h.IsActif && h != null)
            {
                h.Vec = new Vector3(Random.Range(GameVariables.terrainXmin, GameVariables.terrainXmax), h.transform.position.y, Random.Range(GameVariables.terrainZmin, GameVariables.terrainZmax));
                h.V = h.Vec - h.transform.position;
            }
        }
    }
}
