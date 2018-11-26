using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetToggleColors : MonoBehaviour
{
    public const string dropDownMut = "DropdownMut";
    public const string toggleMut = "ToggleMut";

    public const string dropDownKlugheit = "DropdownKlugheit";
    public const string toggleKlugheit = "ToggleKlugheit";

    public const string dropDownIntuition = "DropdownIntuition";
    public const string toggleIntuition  = "ToggleIntuition";

    public const string dropDownCharisma = "DropdownCharisma";
    public const string toggleCharisma = "ToggleCharisma";

    public const string dropDownFingerfertigkeit = "DropdownFingerfertigkeit";
    public const string toggleFingerfertigkeit = "ToggleFingerfertigkeit";

    public const string dropDownGewandtheit = "DropdownGewandtheit";
    public const string toggleGewandtheit = "ToggleGewandtheit";

    public const string dropDownKonstitution = "DropdownKonstitution";
    public const string toggleKonstitution = "ToggleKonstitution";

    public const string dropDownKörperkraft = "DropdownKörperkraft";
    public const string toggleKörperkraft = "ToggleKörperkraft";


    public Toggle mutToggle, klugToggle, intuitionToggle, charismaToggle, ffToggle, gwToggle, koToggle, kkToggle;

    #region Eventhandler Mut
    public void mutToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownMut);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_MUT);
    }


    public void mutDropdownDiceNumberChanged(int chosenIndex){
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleMut);
    }
    #endregion

    #region Eventhandler Klugheit
    public void klugheitToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownKlugheit);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_KLUG);
    }

    public void klugheitDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleKlugheit);
    }
    #endregion

    #region Eventhandler Intuition
    public void intuitionToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownIntuition);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_INTUITION);

    }

    public void intuitionDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleIntuition);
    }
    #endregion

    #region Eventhandler Charisma
    public void charismaToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownCharisma);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_CHARISMA);
    }

    public void charismaDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleCharisma);
    }
    #endregion

    #region Eventhandler FF
    public void fingerfertigkeitToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownFingerfertigkeit);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_FF);
    }

    public void fingerfertigkeitDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleFingerfertigkeit);
    }
    #endregion

    #region Eventhandler #Gewandtheit
    public void gewandtheitToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownGewandtheit);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_GW);

    }

    public void gewandtheitDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleGewandtheit);
    }
    #endregion  

    #region Eventhandler KO
    public void konstitutionToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownKonstitution);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_KO);

    }

    public void konstitutionDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleKonstitution);
    }
    #endregion

    #region Eventhandler KK
    public void koerperkraftToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownKörperkraft);
        setPrefabName(activated, ToolboxDice.DSA_D20_PREFAB_NAME_KK);

    }

    public void koerperkraftDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool actived = GetToggleValue(toggleKörperkraft);
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

    private void setDSADiceChosen(){
        
    }
    #endregion

    #region UI-Helpers
    private int GetNumberDice(string dropDownName)
    {
        Dropdown dropdownGO = GameObject.Find(dropDownName).GetComponent<Dropdown>();
        int numberDice = dropdownGO.value + 1;
        return numberDice;
    }

    private bool GetToggleValue(string toggleName)
    {
        Toggle toggleComponent = GameObject.Find(toggleName).GetComponent<Toggle>();
        bool activated = toggleComponent.isOn;
        return activated;
    }
    #endregion
}
