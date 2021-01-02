using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class Batiment : MonoBehaviour
{
    public float size = 0.5f;
    protected GameObject batiment;
    static bool actionPossible;
    public GameObject spawn;

    Color color;
    bool deplacement; public bool isEnDeplacement() { return this.deplacement; }
    private bool clic;

    public string description;
    public string nomBatiment;
    public string description2;
    public string nbHabitants;
    public int nbrMaxHab;
    public int pointsVie;

    public enum role
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

    public int priceGold;
    public int priceMeat;
    public int priceWood;
    public int priceMana;
    public int priceIron;


    public GameObject batUpgrade;

    protected List<GameObject> listHabitants;
    protected List<Color> prefabModelColorChild;
    protected List<GameObject> modelChild;

    public List<GameObject> ListHabitants { get => listHabitants; set => listHabitants = value; }
    public GameObject Spawn { get => spawn; set => spawn = value; }

    void Awake()
    {
        ListHabitants = new List<GameObject>();
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        batiment = gameObject.transform.Find("Delimitation").gameObject;
        batiment.SetActive(false);
        color = GetComponent<Renderer>().material.color;
        deplacement = true;
        clic = true;
        batiment.GetComponent<Renderer>().material.color = Color.green;
        GetComponent<Renderer>().material.color = Color.green;
        batiment.SetActive(true);
        
        actionPossible = false;
        GetPartModel();
        ChangeBatColor(Color.green);
    }
    
    protected void GetPartModel()
    {
        prefabModelColorChild = new List<Color>();
        modelChild = new List<GameObject>();
        modelChild.Add(this.gameObject.transform.Find("Model").gameObject);

        for (int i = 0; i < modelChild.Count; i++)
        {
            if (modelChild[i].transform.childCount > 0)
            {
                foreach (Transform child in modelChild[i].transform)
                {
                    modelChild.Add(child.gameObject);
                    if (child.GetComponent<MeshRenderer>() != null)
                    {
                        foreach (Material material in child.GetComponent<MeshRenderer>().materials)
                        {
                            prefabModelColorChild.Add(material.color);
                        }
                    }
                    if (child.GetComponent<SpriteRenderer>() != null)
                    {
                        prefabModelColorChild.Add(child.GetComponent<SpriteRenderer>().color);

                    }

                }
            }
        }

    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (GameVariables.batimentSelectionne == this)
        {
            int nb = GameVariables.batimentSelectionne.ListHabitants.Count;
            for (int i = 0; i < ListHabitants.Count; i++)
            {
                if (ListHabitants[i] == null)
                {
                    nb--;
                    ListHabitants.RemoveAt(i);
                }
            }

        }

        //Si le batiment est en attente d'être placé et que le bouton gauche de la souris est maintenu,
        //Alors l'objet suit le curseur de la souris
        if (deplacement && Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = new Vector3(transform.position.x + size, transform.position.y, transform.position.z);
            }
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = new Vector3(transform.position.x - size, transform.position.y, transform.position.z);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + size);
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - size);
            }
            //transform.Translate(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
        }

        //Si clic droit de la souris, le batiment est placé sur le terrain si possible

        if (Input.GetMouseButton(1) && clic && deplacement && canBeConstruct())
        {
            validateLocation();
            constructBat();

        }
    }

    //Met le batiment rouge si impossible de placer
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Terrain") || other.CompareTag("BatimentLimit") || other.CompareTag("Habitant") || other.CompareTag("Ennemi")) && batiment != null && deplacement)
        {
            ChangeBatColor(Color.red);
            clic = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.CompareTag("Terrain") || other.CompareTag("BatimentLimit") || other.CompareTag("Habitant") || other.CompareTag("Ennemi")) && batiment != null && deplacement && clic == true)
        {
            ChangeBatColor(Color.red);
            clic = false;
        }
    }

    //Met le batiment en vert si possible de la placer
    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Terrain") || other.CompareTag("BatimentLimit") || other.CompareTag("Habitant") || other.CompareTag("Ennemi")) && batiment != null && deplacement)
        {
            ChangeBatColor(Color.green);
            clic = true;
        }
    }

    //met le batiment en surbrillance si on le survole
    private void OnMouseOver()
    {
        if (!deplacement && batiment != null && !BuildingManagementUI.getInstance().isOpen() && actionPossible)
        {
            ChangeBatColor(Color.yellow);

        }
    }

    //remet l'objet normal et ferme l'affichage des choix en quittant le survolement
    private void OnMouseExit()
    {
        if (!deplacement && batiment != null)
        {
            int it = 0;

            for (int i = 0; i < modelChild.Count; i++)
            {

                if (modelChild[i].GetComponent<MeshRenderer>() != null)
                {
                    foreach (Material material in modelChild[i].GetComponent<MeshRenderer>().materials)
                    {
                        material.color = prefabModelColorChild[it];
                        it++;
                    }
                }
                if (modelChild[i].GetComponent<SpriteRenderer>() != null)
                {
                    modelChild[i].GetComponent<SpriteRenderer>().color = prefabModelColorChild[it];
                    it++;
                }

            }
        }
    }

    //Affiche les choix possibles et la description
    private void OnMouseUp()
    {
        if (BuildingManagementUI.getInstance() != null && !BuildingManagementUI.getInstance().isOpen()) afficheCanvas();
    }

    public void ChangeBatColor(Color c)
    {
        for (int i = 0; i < modelChild.Count; i++)
        {
            if (modelChild[i].GetComponent<MeshRenderer>() != null)
            {
                foreach (Material material in modelChild[i].GetComponent<MeshRenderer>().materials)
                {
                    material.color = c;
                }
            }
            if (modelChild[i].GetComponent<SpriteRenderer>() != null)
            {
                modelChild[i].GetComponent<SpriteRenderer>().color = c;
            }

        }
        GameObject o = this.gameObject.transform.Find("Delimitation").gameObject;
        if (o.transform.childCount > 0)
        {
            foreach (Transform child in o.transform)
            {
                if (child.GetComponent<MeshRenderer>() != null)
                {
                    foreach (Material material in child.GetComponent<MeshRenderer>().materials)
                    {
                        material.color = c;
                    }

                }
            }
        }
    }
    public void desactiverCanvas()
    {
        if(BuildingManagementUI.getInstance() != null)
            BuildingManagementUI.getInstance().closeBuildingManagement();
    }

    public void afficheCanvas()
    {
        if (BuildingManagementUI.getInstance() != null && !deplacement && batiment != null && actionPossible)
            BuildingManagementUI.getInstance().openBuildingManagement(this);
    }

    public abstract void upgradeStructure();

    public void validateLocation()
    {
        actionPossible = true;
        deplacement = false;
        batiment.transform.GetChild(0).gameObject.SetActive(false);
        // GetComponent<Renderer>().material.color = color;
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
        transform.position = transform.position + new Vector3(0, -0.2f, 0);
        for (int i = 0; i < modelChild.Count; i++)
        {
            if (modelChild[i].GetComponent<MeshRenderer>() != null)
            {
                foreach (Material material in modelChild[i].GetComponent<MeshRenderer>().materials)
                {
                    material.color = prefabModelColorChild[i];
                }
            }
            if (modelChild[i].GetComponent<SpriteRenderer>() != null)
            {
                modelChild[i].GetComponent<SpriteRenderer>().color = prefabModelColorChild[i]; ;
            }

        }

    }

    public bool canBeConstruct()
    {
        bool t = (GameVariables.nbWood >= priceWood && GameVariables.nbGold >= priceGold && GameVariables.nbMeat >= priceMeat && GameVariables.nbMana >= priceMana && GameVariables.nbIron >= priceIron);
        return t;
    }

    public void constructBat()
    {
        GameVariables.nbWood -= priceWood;
        GameVariables.nbGold -= priceGold;
        GameVariables.nbMeat -= priceMeat;
        GameVariables.nbMana -= priceMana;
        GameVariables.nbIron -= priceIron;
    }
}
