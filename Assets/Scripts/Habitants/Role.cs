using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Role : MonoBehaviour
{
    public enum role // your custom enumeration
    {
        Habitant,
        Combattant
    };
    public role typeHabitant;

    public GameObject combattant;
    public GameObject habitant;

    // Start is called before the first frame update
    void Start()
    {
       //changementRole(typeHabitant.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public GameObject changementRole(string type)
    {
        string str = GetComponent<Habitant>().Type;
        switch (str)
        {
            case "Habitant":
                Destroy(GetComponent<Habitant>());
                break;
            /*case "Combattant":
                Destroy(GetComponent<Combattant>());
                break;*/
        }

        //Récupère l'emplacement de l'outils pour le rôle attribué
        GameObject o = gameObject;
        for (int i = 0; i < 6; i++)
        {
            o = o.transform.GetChild(0).gameObject;
        }
        o = o.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;

        switch (type)
        {
            case "Combattant":
                gameObject.AddComponent<Combattant>();
                GetComponent<Combattant>().pointsVie = combattant.GetComponent<Combattant>().pointsVie;
                GetComponent<Combattant>().pointsAttaque = combattant.GetComponent<Combattant>().pointsAttaque;
                GetComponent<Combattant>().speed = combattant.GetComponent<Combattant>().speed;
                GetComponent<Combattant>().survie = combattant.GetComponent<Combattant>().survie;
                GetComponent<Combattant>().quantiteConso = combattant.GetComponent<Combattant>().quantiteConso;

                gameObject.GetComponent<Animator>().runtimeAnimatorController = combattant.GetComponent<Animator>().runtimeAnimatorController;
               
                o = o.transform.GetChild(4).gameObject;
                o.SetActive(true);
                break;
         /*      
            case "Habitant":
                gameObject.AddComponent<Habitant>();
                gameObject.GetComponent<Habitant>().pointsVie = habitant.GetComponent<Habitant>().pointsVie;
                gameObject.GetComponent<Habitant>().speed = habitant.GetComponent<Habitant>().speed;

                gameObject.GetComponent<Animator>().runtimeAnimatorController = habitant.GetComponent<Animator>().runtimeAnimatorController;
                //gameObject.GetComponent<Animator>().ani
                break;*/
        }
        return gameObject;
    }
}
