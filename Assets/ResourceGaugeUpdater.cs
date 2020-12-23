using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceGaugeUpdater : MonoBehaviour
{
    public Image resourceBar;
    public TMP_Text resourceText;

    // Update is called once per frame
    public void UpdateGauge(int resourceCurrentValue, int resourceMaxValue)
    {
        resourceText.text = resourceCurrentValue.ToString();
        resourceBar.fillAmount = (((float)resourceCurrentValue) / ((float)resourceMaxValue));
    }
}
