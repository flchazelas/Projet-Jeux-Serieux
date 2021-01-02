using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{

    public float speed = 1;
    private bool isActif;
    public int pointsVie;
    public int pointsAttaque;

    Transform target;

    private float allowedTime = 1;
    private float currentTime = 0;
    private bool isFighting;
    Habitant habitant;
    NavMeshAgent agent;
    public bool IsActif { get => isActif; set => isActif = value; }

    // Start is called before the first frame update
    void Start()
    {
        isActif = false;
        habitant = null;
        isFighting = false;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        searchHabitant();
        if (habitant!=null)
        {
            target = habitant.transform;
            if(!isFighting)
                agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }

        agent.SetDestination(target.position);
        print(agent.velocity);
        if (agent.velocity.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            /*transform.position = Vector3.MoveTowards(transform.position, new Vector3(Vec.x, 0, Vec.z), speed * Time.deltaTime);
            if(V != Vector3.zero)
            transform.forward = V;
            if (transform.position == new Vector3(Vec.x, transform.position.y, Vec.z))
            {
                GetComponent<Animator>().SetBool("isWalking", false);
            }*/
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
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

    public void searchHabitant()
    {
        float closestHabitant = 1000f;
        if (FindObjectsOfType<Habitant>().Length != 0)
        {
            foreach (Habitant h in FindObjectsOfType<Habitant>())
            {
                float val = Vector3.Distance(transform.position, h.transform.position);
                if (val < closestHabitant)
                {
                    closestHabitant = val;
                    habitant = h;
                }
            }

        }
        else
        {
            habitant = null;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Habitant"))
        {
            print(habitant);
            habitant = collision.transform.GetComponent<Habitant>();
            print(habitant);
            if (currentTime == 0)
            {
                GetComponent<Animator>().SetBool("isWalking", false);

                currentTime = allowedTime;
                GetComponent<Animator>().SetBool("isFighting", true);
                StartCoroutine("Combattre", habitant);
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
    IEnumerator Combattre()
    {
        isFighting = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(1);
        currentTime--;
        GetComponent<Animator>().SetBool("isFighting", false);
        if (habitant != null)
        {
            habitant.pointsVie -= pointsAttaque;
        }
        agent.isStopped = false;
        isFighting = false;
    }

    IEnumerator Attendre()
    {
        yield return new WaitForSeconds(1);
        IsActif = false;
    }
}
