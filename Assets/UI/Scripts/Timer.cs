using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Time");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameVariables.timer.ToString();
    }

    IEnumerator Time()
    {
        print(GameVariables.timer);
        while(GameVariables.timer != 0)
        {
            yield return new WaitForSeconds(1);
            GameVariables.timer--;
        }
    }
}
