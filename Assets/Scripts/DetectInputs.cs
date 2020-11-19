using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInputs : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Affiche les entrées clavier
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
                print("Keycode = " + keyCode);
        }
    }
}
