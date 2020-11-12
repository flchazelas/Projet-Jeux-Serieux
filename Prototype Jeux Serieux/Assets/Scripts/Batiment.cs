using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Batiment : MonoBehaviour
{
    public float size = 0.5f;
    GameObject batiment;
    GameObject canvas;
    Color color;
    bool deplacement;
    bool clic;
    public string description;
    public string nbHabitants;

    List<Habitant> listHabitants;

    Text desc;
    Text habitants;

    public List<Habitant> ListHabitants { get => listHabitants; set => listHabitants = value; }

    // Start is called before the first frame update
    void Start()
    {
        ListHabitants = new List<Habitant>();

        batiment = gameObject.transform.Find("Delimitation").gameObject;
        batiment.SetActive(false);
        color = GetComponent<Renderer>().material.color;
        deplacement = true;
        clic = true;
        batiment.GetComponent<Renderer>().material.color = Color.green;
        GetComponent<Renderer>().material.color = Color.green;
        batiment.SetActive(true);

        canvas = GameObject.Find("Canvas Batiment");
        desc = canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("Description").GetComponent<Text>();
        desc.text = description;
        habitants = canvas.transform.Find("Image Fond").GetComponent<Image>().transform.Find("Nb Habitants Affectés").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameVariables.batimentSelectionne != null)
        {
            habitants.text = nbHabitants + GameVariables.batimentSelectionne.ListHabitants.Count.ToString();
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
            deplacement = false;
            batiment.SetActive(false);
            GetComponent<Renderer>().material.color = color;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    //Met le batiment rouge si impossible de placer
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain") || other.CompareTag("Batiment"))
        {
            batiment.GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Renderer>().material.color = Color.red;
            clic = false;
        }
    }

    //Met le batiment en vert si possible de la placer
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Terrain") || other.CompareTag("Batiment"))
        {
            batiment.GetComponent<Renderer>().material.color = Color.green;
            GetComponent<Renderer>().material.color = Color.green;
            clic = true;
        }
    }

    //met le batiment en surbrillance si on le survole
    private void OnMouseOver()
    {
        if (!deplacement)
        {
            batiment.GetComponent<Renderer>().material.color = Color.yellow;
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    //remet l'objet normal et ferme l'affichage des choix en quittant le survolement
    private void OnMouseExit()
    {
        if (!deplacement)
        {
            batiment.GetComponent<Renderer>().material.color = color;
            GetComponent<Renderer>().material.color = color;
        }
    }

    //Affiche les choix possibles et la description
    private void OnMouseDown()
    {
        if (!deplacement)
        {
            canvas.GetComponent<Canvas>().enabled = true;
            GameVariables.batimentSelectionne = this;
        }
    }

    public void desactiverCanvas()
    {
        canvas = GameObject.Find("Canvas Batiment");
        canvas.GetComponent<Canvas>().enabled = false;
    }
}
