using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    private Vector3 vec;
    private Vector3 v;
    public float speed = 1;
    private bool isActif;
    public int pointsVie;
    public int pointsAttaque;

    private float allowedTime = 1;
    private float currentTime = 0;

    Habitant habitant;

    public Vector3 Vec { get => vec; set => vec = value; }
    public Vector3 V { get => v; set => v = value; }
    public bool IsActif { get => isActif; set => isActif = value; }

    // Start is called before the first frame update
    void Start()
    {
        Vec = new Vector3(0, 0, 0);
        V = new Vector3(0, 0, 0);
        isActif = false;
        habitant = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActif)
        {
            calculDistance();
            GetComponent<Animator>().SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Vec.x, 0, Vec.z), speed * Time.deltaTime);
            transform.forward = V;
            if (transform.position == new Vector3(Vec.x, transform.position.y, Vec.z))
            {
                GetComponent<Animator>().SetBool("isWalking", false);
            }
        }
        else if(habitant == null)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            IsActif = false;
        }

        if (!isAlive())
        {
            Destroy(gameObject);
        }
    }

    public bool isAlive()
    {
        if(pointsVie <= 0)
            return false;
        else
            return true;
    }

    public void calculDistance()
    {
        float distance = 1000f;
        if (FindObjectsOfType<Habitant>().Length != 0) {
            foreach (Habitant h in FindObjectsOfType<Habitant>())
            {
                float val = Mathf.Sqrt(Mathf.Pow(transform.position.x - h.transform.position.x, 2f) + Mathf.Pow(transform.position.z - h.transform.position.z, 2f));
                if (val < distance)
                {
                    distance = val;
                    habitant = h;
                }
            }

            Vec = new Vector3(habitant.transform.position.x, habitant.transform.position.y, habitant.transform.position.z);
            V = Vec - transform.position;
        }
        else
        {
            Vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Habitant"))
        {
            habitant = collision.transform.GetComponent<Habitant>();
            if (currentTime == 0)
            {
                GetComponent<Animator>().SetBool("isWalking", false);
                Vec = new Vector3(Vec.x, Vec.y, Vec.z);
                V = new Vector3(0, 0, 0);
                IsActif = true;
                currentTime = allowedTime;
                GetComponent<Animator>().SetBool("isFighting", true);
                StartCoroutine("Timer", habitant);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Habitant"))
        {
            StartCoroutine("Attendre");
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Habitant"))
        {
            habitant = other.GetComponent<Habitant>();
            if (currentTime == 0)
            {
                GetComponent<Animator>().SetBool("isWalking", false);
                Vec = new Vector3(Vec.x, Vec.y, Vec.z);
                V = new Vector3(0, 0, 0);
                IsActif = true;
                currentTime = allowedTime;
                GetComponent<Animator>().SetBool("isFighting", true);
                StartCoroutine("Timer", habitant);
            }
        }
    }*/
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Habitant"))
        {
            StartCoroutine("Attendre");
        }
    }
    */
    IEnumerator Timer(Habitant other)
    {
        yield return new WaitForSeconds(1);
        currentTime--;
        GetComponent<Animator>().SetBool("isFighting", false);
        if (other != null)
        {
            other.pointsVie -= pointsAttaque;
        }
    }

    IEnumerator Attendre()
    {
        yield return new WaitForSeconds(1);
        IsActif = false;
    }
}
