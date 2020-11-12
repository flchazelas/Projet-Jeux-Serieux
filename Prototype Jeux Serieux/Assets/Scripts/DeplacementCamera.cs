using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Deplacements camera
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        //Zoom camera
        if (Input.GetKey(KeyCode.Z) && transform.position.y <= 20)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= 1)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        //Rotation camera
        if (Input.GetKey(KeyCode.A) && transform.position.y <= 20)
        {
            transform.Rotate(0, speed * 2.0f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E) && transform.position.y >= 1)
        {
            transform.Rotate(0, -speed * 2.0f * Time.deltaTime, 0);
        }
    }
}
