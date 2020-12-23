using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public abstract class Batiment : MonoBehaviour
{
    public float size = 0.5f;
    GameObject batiment;
    GameObject canvas;
    public GameObject spawn;

    Color color;
    bool deplacement;
    bool clic;
    public string description;
    public string nbHabitants;
    public int nbrMaxHab;

    public enum role
    {
        Habitant,
        Combattant,
        Fermier
    };
    public role typeHabitant;

    public int priceUpgradeGold;
    public int priceUpgradeMeat;
    public int priceUpgradeWood;

    public GameObject batUpgrade;

    protected List<GameObject> listHabitants;

    protected Text desc;
    Text habitants;

    Button upgradeButton;
    Button closeButton;

    public List<GameObject> ListHabitants { get => listHabitants; set => listHabitants = value; }
    public GameObject Spawn { get => spawn; set => spawn = value; }



    // Start is called before the first frame update
    public virtual void Start()
    {
        ListHabitants = new List<GameObject>();

        batiment = gameObject.transform.Find("Delimitation").gameObject;
        batiment.SetActive(false);
        color = GetComponent<Renderer>().material.color;
        deplacement = true;
        clic = true;
        batiment.GetComponent<Renderer>().material.color = Color.green;
        GetComponent<Renderer>().material.color = Color.green;
        batiment.SetActive(true);

        canvas = GameObject.Find("Canvas Batiment");
        upgradeButton = canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("Upgrade").GetComponent<Button>();
        closeButton = canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("Fermer").GetComponent<Button>();
        desc = canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("Description").GetComponent<Text>();
        desc.text = description;
        habitants = canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("Nb Habitants Affectés").GetComponent<Text>();
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
            habitants.text = nbHabitants + nb;
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
        if (Input.GetMouseButton(1) && clic){
            validateLocation();
        }
    }

    //Met le batiment rouge si impossible de placer
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Terrain") || other.CompareTag("Batiment") || other.CompareTag("Habitant") || other.CompareTag("Ennemi")) && batiment != null)
        {
            batiment.GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Renderer>().material.color = Color.red;
            clic = false;
        }
    }

    //Met le batiment en vert si possible de la placer
    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Terrain") || other.CompareTag("Batiment") || other.CompareTag("Habitant") || other.CompareTag("Ennemi")) && batiment != null)
        {
            batiment.GetComponent<Renderer>().material.color = Color.green;
            GetComponent<Renderer>().material.color = Color.green;
            clic = true;
        }
    }

    //met le batiment en surbrillance si on le survole
    private void OnMouseOver()
    {
        if (!deplacement && batiment != null)
        {

            batiment.GetComponent<Renderer>().material.color = Color.yellow;
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    //remet l'objet normal et ferme l'affichage des choix en quittant le survolement
    private void OnMouseExit()
    {
        if (!deplacement && batiment != null)
        {
            batiment.GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.color = color;
        }
    }

    //Affiche les choix possibles et la description
    private void OnMouseDown()
    {
        afficheCanvas();
    }

    public void desactiverCanvas()
    {
        canvas = GameObject.Find("Canvas Batiment");
       // upgradeButton.onClick.RemoveListener(() => { upgradeStructure(); });
        closeButton.onClick.RemoveListener(() => { desactiverCanvas(); });
        canvas.GetComponent<Canvas>().enabled = false;
    }

    public void afficheCanvas()
    {
        if (!deplacement && batiment != null)
        {
            canvas.GetComponent<Canvas>().enabled = true;
            GameVariables.batimentSelectionne = this;
            if (batUpgrade != null)
            {
                upgradeButton.gameObject.SetActive(true);
                upgradeButton.onClick.AddListener(() => { upgradeStructure(); });
            }
            else
            {
                upgradeButton.gameObject.SetActive(false);

            }
            closeButton.onClick.AddListener(() => { desactiverCanvas(); });
            desc.text = description;
        }
    }

    public abstract void upgradeStructure();
    

    public void validateLocation()
    {
        deplacement = false;
        batiment.SetActive(false);
        GetComponent<Renderer>().material.color = color;
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
