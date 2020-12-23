using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteBehaviour : MonoBehaviour
{
    public GameObject cam;
    public Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detecte si la camera atteint une limite
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            cam.transform.position = new Vector3(cam.transform.position.x + vec.x, cam.transform.position.y, cam.transform.position.z + vec.z);
        }
    }

    //Detecte si la camera atteint une limite
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            cam.transform.position = new Vector3(cam.transform.position.x + vec.x, cam.transform.position.y, cam.transform.position.z + vec.z);
        }
    }
}
