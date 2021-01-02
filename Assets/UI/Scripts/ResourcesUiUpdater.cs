using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUiUpdater : MonoBehaviour
{
    public ResourceGaugeUpdater foodGauge;
    public ResourceGaugeUpdater woodGauge;
    public ResourceGaugeUpdater ironGauge;
    public ResourceGaugeUpdater goldGauge;
    public ResourceGaugeUpdater manaGauge;
    public ResourceGaugeUpdater popGauge;

    public void Update()
    {
        foodGauge.UpdateGauge(GameVariables.nbMeat, GameVariables.maxMeat);
        woodGauge.UpdateGauge(GameVariables.nbWood, GameVariables.maxWood);
        ironGauge.UpdateGauge(GameVariables.nbIron, GameVariables.maxIron);
        goldGauge.UpdateGauge(GameVariables.nbGold, GameVariables.maxGold);
        manaGauge.UpdateGauge(GameVariables.nbMana, GameVariables.maxMana);
        popGauge.UpdateGauge(GameVariables.nbHabitants, GameVariables.nbHabitants);
    }
}
