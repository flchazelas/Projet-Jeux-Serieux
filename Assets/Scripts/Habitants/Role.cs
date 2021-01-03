using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Role : MonoBehaviour
{
    public enum role // your custom enumeration
    {
        Habitant,
        Combattant,
        Fermier,
        Mineur,
        Bucheron,
        Marchand,
        Pretre
    };
    public role typeHabitant;

    public GameObject combattant;
    public GameObject habitant;
    public GameObject fermier;
    public GameObject mineur;
    public GameObject bucheron;
    public GameObject marchand;
    public GameObject pretre;

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
        //Récupère l'emplacement de l'outils pour le rôle attribué
        GameObject o = gameObject;
        for (int i = 0; i < 6; i++)
        {
            o = o.transform.GetChild(0).gameObject;
        }
        o = o.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;

        string str = typeHabitant.ToString();

        switch (type)
        {
            case "Combattant":
                gameObject.AddComponent<Combattant>();
                GetComponent<Combattant>().pointsVie = combattant.GetComponent<Combattant>().pointsVie;
                GetComponent<Combattant>().pointsAttaque = combattant.GetComponent<Combattant>().pointsAttaque;
                GetComponent<Combattant>().speed = combattant.GetComponent<Combattant>().speed;
                GetComponent<Combattant>().survie = combattant.GetComponent<Combattant>().survie;
                GetComponent<Combattant>().quantiteConso = combattant.GetComponent<Combattant>().quantiteConso;
                typeHabitant = role.Combattant;

                gameObject.GetComponent<Animator>().runtimeAnimatorController = combattant.GetComponent<Animator>().runtimeAnimatorController;

                o = o.transform.GetChild(4).gameObject;
                o.SetActive(true);
                break;

            case "Fermier":
                gameObject.AddComponent<Fermier>();
                GetComponent<Fermier>().pointsVie = GetComponent<Habitant>().pointsVie;
                GetComponent<Fermier>().speed = fermier.GetComponent<Fermier>().speed;
                GetComponent<Fermier>().survie = GetComponent<Habitant>().survie;
                GetComponent<Fermier>().quantiteConso = fermier.GetComponent<Fermier>().quantiteConso;
                GetComponent<Fermier>().Spawn = GetComponent<Habitant>().Spawn;
                typeHabitant = role.Fermier;



                GetComponent<Animator>().runtimeAnimatorController = fermier.GetComponent<Animator>().runtimeAnimatorController;

                o = o.transform.GetChild(5).gameObject;
                o.SetActive(true);
                break;

            case "Mineur":
                gameObject.AddComponent<Mineur>();
                GetComponent<Mineur>().pointsVie = GetComponent<Habitant>().pointsVie;
                GetComponent<Mineur>().speed = mineur.GetComponent<Mineur>().speed;
                GetComponent<Mineur>().survie = GetComponent<Habitant>().survie;
                GetComponent<Mineur>().quantiteConso = mineur.GetComponent<Mineur>().quantiteConso;
                GetComponent<Mineur>().Spawn = GetComponent<Habitant>().Spawn;
                typeHabitant = role.Mineur;


                GetComponent<Animator>().runtimeAnimatorController = mineur.GetComponent<Animator>().runtimeAnimatorController;

                o = o.transform.GetChild(6).gameObject;
                o.SetActive(true);
                break;

            case "Bucheron":
                gameObject.AddComponent<Bucheron>();
                GetComponent<Bucheron>().pointsVie = GetComponent<Habitant>().pointsVie;
                GetComponent<Bucheron>().speed = bucheron.GetComponent<Bucheron>().speed;
                GetComponent<Bucheron>().survie = GetComponent<Habitant>().survie;
                GetComponent<Bucheron>().quantiteConso = bucheron.GetComponent<Bucheron>().quantiteConso;
                GetComponent<Bucheron>().Spawn = GetComponent<Habitant>().Spawn;
                typeHabitant = role.Bucheron;


                GetComponent<Animator>().runtimeAnimatorController = bucheron.GetComponent<Animator>().runtimeAnimatorController;

                o = o.transform.GetChild(7).gameObject;
                o.SetActive(true);
                break;

            case "Marchand":
                gameObject.AddComponent<Marchand>();

                GetComponent<Marchand>().pointsVie = GetComponent<Habitant>().pointsVie;
                float speed= marchand.GetComponent<Marchand>().speed;
                GetComponent<Marchand>().speed = speed;
                GetComponent<Marchand>().survie = GetComponent<Habitant>().survie;
                GetComponent<Marchand>().quantiteConso = marchand.GetComponent<Marchand>().quantiteConso;
                GetComponent<Marchand>().Spawn = GetComponent<Habitant>().Spawn;
                typeHabitant = role.Marchand;

                GetComponent<Animator>().runtimeAnimatorController = marchand.GetComponent<Animator>().runtimeAnimatorController;

                break;

            case "Pretre":
                gameObject.AddComponent<Pretre>();
                
                GetComponent<Pretre>().pointsVie = GetComponent<Habitant>().pointsVie;
                GetComponent<Pretre>().speed = pretre.GetComponent<Pretre>().speed;
                GetComponent<Pretre>().survie = GetComponent<Habitant>().survie;
                GetComponent<Pretre>().quantiteConso = pretre.GetComponent<Pretre>().quantiteConso;
                GetComponent<Pretre>().Spawn = GetComponent<Habitant>().Spawn;
                typeHabitant = role.Pretre;


                GetComponent<Animator>().runtimeAnimatorController = pretre.GetComponent<Animator>().runtimeAnimatorController;
                break;

            case "Habitant":
                if (GetComponent<Habitant>().random_object == null)
                {
                    GetComponent<Habitant>().random_object = new GameObject(); GetComponent<Habitant>().random_object.transform.position = new Vector3(Random.Range(GameVariables.terrainXmin, GameVariables.terrainXmax), 0, Random.Range(GameVariables.terrainZmin, GameVariables.terrainZmax));
                    GetComponent<Habitant>().target = GetComponent<Habitant>().random_object.transform;
                }
                GetComponent<Habitant>().pointsVie = habitant.GetComponent<Habitant>().pointsVie;
                GetComponent<Habitant>().speed = habitant.GetComponent<Habitant>().speed;
                GetComponent<Habitant>().survie = habitant.GetComponent<Habitant>().survie;
                GetComponent<Habitant>().quantiteConso = habitant.GetComponent<Habitant>().quantiteConso;
                GetComponent<Habitant>().Spawn = habitant.GetComponent<Habitant>().Spawn;
                GetComponent<Habitant>().enabled = true;
                typeHabitant = role.Habitant;

                GetComponent<Animator>().runtimeAnimatorController = habitant.GetComponent<Animator>().runtimeAnimatorController;
                
                break;

        }

        print(str);
        switch (str)
        {
            case "Habitant":
                Destroy(GetComponent<Habitant>().random_object);
                GetComponent<Habitant>().random_object = null;
                GetComponent<Habitant>().enabled = false; 
                //GetComponent<Habitant>().enabled = true;
                break;
            case "Fermier":
                o = o.transform.GetChild(5).gameObject;
                o.SetActive(false);
                Destroy(GetComponent<Fermier>());
                break;
            case "Combattant":
                Destroy(GetComponent<Combattant>().random_object);
                GetComponent<Combattant>().random_object = null;
                o = o.transform.GetChild(4).gameObject;
                o.SetActive(false);
                Destroy(GetComponent<Combattant>());
                break;
            case "Mineur":
                o = o.transform.GetChild(6).gameObject;
                o.SetActive(false);
                Destroy(GetComponent<Mineur>());
                break;
            case "Bucheron":
                o = o.transform.GetChild(7).gameObject;
                o.SetActive(false);
                Destroy(GetComponent<Bucheron>());
                break;
            case "Marchand":
                Destroy(GetComponent<Marchand>().random_object);
                GetComponent<Marchand>().random_object = null;
                Destroy(GetComponent<Marchand>());
                break;
            case "Pretre":
                Destroy(GetComponent<Pretre>().random_object);
                GetComponent<Pretre>().random_object = null;
                Destroy(GetComponent<Pretre>());
                break;
        }

        return gameObject;
    }
}
