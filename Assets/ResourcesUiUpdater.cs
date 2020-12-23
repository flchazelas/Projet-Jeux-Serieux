using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUiUpdater : MonoBehaviour
{
    public ResourceGaugeUpdater foodGauge;
    public ResourceGaugeUpdater woodGauge;
    public ResourceGaugeUpdater goldGauge;
    public ResourceGaugeUpdater popGauge;

    public void Update()
    {
        foodGauge.UpdateGauge(GameVariables.nbMeat, GameVariables.maxMeat);
        woodGauge.UpdateGauge(GameVariables.nbWood, GameVariables.maxWood);
        goldGauge.UpdateGauge(GameVariables.nbGold, GameVariables.maxGold);
        popGauge.UpdateGauge(GameVariables.nbHabitants, GameVariables.nbHabitants);
    }
}
