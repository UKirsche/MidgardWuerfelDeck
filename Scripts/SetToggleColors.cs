using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetToggleColors : MonoBehaviour
{

    public Toggle mutToggle, klugToggle, intuitionToggle, charismaToggle, ffToggle, gwToggle, koToggle, kkToggle;

    #region Event Handlers
    public void mutToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_MUT);
    }

    public void klugheitToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_KLUG);
    }

    public void intuitionToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_INTUITION);

    }

    public void charismaToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_CHARISMA);
    }

    public void fingerfertigkeitToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_FF);
    }

    public void gewandtheitToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_GW);

    }

    public void konstitutionToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_KK);

    }

    public void koerperkraftToggleButtonClicked(bool activated)
    {
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_KK);

    }

    #endregion

    #region Helpers zum Setzen der Prefabsnamen
    private void setPrefabName(bool activated, string prefabName)
    {
        ToolboxDice diceVar = ToolboxDice.Instance;

        if (activated)
        {
            diceVar.dsaChosenPrefabs.Add(prefabName);
            Debug.Log(prefabName + " aktiviert");
        }
        else
        {
            diceVar.dsaChosenPrefabs.Remove(prefabName); 
            Debug.Log(prefabName + " deaktiviert");
        }
    }
    #endregion
}
