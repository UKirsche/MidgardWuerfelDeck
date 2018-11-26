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
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_MUT);

    }

    public void mutDropdownDiceNumberChanged(int chosenIndex){
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleMut);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_MUT);

    }
    #endregion

    #region Eventhandler Klugheit
    public void klugheitToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownKlugheit);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_KLUG);
    }

    public void klugheitDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleKlugheit);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_KLUG);

    }
    #endregion

    #region Eventhandler Intuition
    public void intuitionToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownIntuition);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_INTUITION);

    }

    public void intuitionDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleIntuition);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_INTUITION);
    }
    #endregion

    #region Eventhandler Charisma
    public void charismaToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownCharisma);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_CHARISMA);
    }

    public void charismaDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleCharisma);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_CHARISMA);

    }
    #endregion

    #region Eventhandler FF
    public void fingerfertigkeitToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownFingerfertigkeit);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_FF);
    }

    public void fingerfertigkeitDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleFingerfertigkeit);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_FF);
    }
    #endregion

    #region Eventhandler #Gewandtheit
    public void gewandtheitToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownGewandtheit);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_GW);

    }

    public void gewandtheitDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleGewandtheit);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_GW);

    }
    #endregion  

    #region Eventhandler KO
    public void konstitutionToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownKonstitution);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_KO);

    }

    public void konstitutionDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleKonstitution);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_KO);
    }
    #endregion

    #region Eventhandler KK
    public void koerperkraftToggleButtonClicked(bool activated)
    {
        int numberDice = GetNumberDice(dropDownKörperkraft);
        SetDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_KK);

    }

    public void koerperkraftDropdownDiceNumberChanged(int chosenIndex)
    {
        int numberDice = chosenIndex + 1;
        bool activated = GetToggleValue(toggleKörperkraft);
        ModifyDSADiceChosen(activated, numberDice, ToolboxDice.DSA_D20_PREFAB_NAME_KK);
    }
    #endregion

    #region Helpers zum Setzen der Prefabsnamen
    private void SetDSADiceChosen(bool activated, int numberDice, string prefabName){

        ToolboxDice diceVar = ToolboxDice.Instance;

        if(activated){
            diceVar.dsaDiceChosen.Add(prefabName, numberDice);
            
        } else {
            diceVar.dsaDiceChosen.Remove(prefabName);
        }
        
    }

    private void ModifyDSADiceChosen(bool activated, int numberDice, string prefabName){

        ToolboxDice diceVar = ToolboxDice.Instance;

        if(activated){
            diceVar.dsaDiceChosen[prefabName] = numberDice;
        }
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
