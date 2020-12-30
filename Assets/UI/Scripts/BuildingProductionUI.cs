using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingProductionUI : MonoBehaviour
{
    public Sprite foodIcon;
    public Sprite woodIcon;
    public Sprite ironIcon;
    public Sprite goldIcon;
    public Sprite manaIcon;

    public Image prodIcon;
    public TMP_Text currentProd;
    public TMP_Text prodUnit;

    public void updateProdIcon(Batiment.role typeProd)
    {
        if (typeProd == Batiment.role.Fermier)
                prodIcon.sprite = foodIcon;
        else if (typeProd == Batiment.role.Bucheron)
            prodIcon.sprite = woodIcon;
        else if (typeProd == Batiment.role.Mineur)
            prodIcon.sprite = ironIcon;
        else if (typeProd == Batiment.role.Marchand)
            prodIcon.sprite = goldIcon;
        else if (typeProd == Batiment.role.Pretre)
            prodIcon.sprite = manaIcon;
        else
            prodIcon.sprite = null;
    }

    public void updateCurrentProd(int prodValue)
    {
        currentProd.text = prodValue.ToString();
    }

    public void updateProdUnit(int unitValue, string unitName)
    {
        prodUnit.text = "/ " + unitValue.ToString() + " " + unitName;
    }
}
