using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCostUI : MonoBehaviour
{
    public TMP_Text resourceCost;

    public void updateCurrentProd(int cost)
    {
        resourceCost.text = cost.ToString();
    }
}
