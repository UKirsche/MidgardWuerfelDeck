using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CalculateQualityLevel : MonoBehaviour
{

    public InputField mutInput, intuituionInput, klugheitInput, charismaInput, fingerFertigkeitInput, gewandtheitInput, konstituionInput, koerperkraftInput;
    public InputField bonusMalusInput;
    public InputField ergebnisInput;
    public static int RESULTTHROW;
    private int throwCounter=0;
    private int dicePerThrow = 0;
    private int resultMut, resultKlugheit, resultIntuition, resultCharisma, resultFF, resultGewandtheit, resultKonstitution, resultKoerperkraft;


    private void Start()
    {
        ToolboxDice diceVars = ToolboxDice.Instance;
        dicePerThrow = GetNumberDice(diceVars);
    }

    private int GetNumberDice(ToolboxDice diceVars)
    {
        int numberDice = 0;
        foreach (var prefabName in diceVars.dsaDiceChosen.Keys)
        {
            numberDice += diceVars.dsaDiceChosen[prefabName];
        }
        return numberDice;
    }

    #region Eventhandling wenn Würfel ruhig ist
    void OnEnable()
    {
        DiceStopChecker.onStill += HandleOnDiceSet;
    }

    void OnDisable()
    {
        DiceStopChecker.onStill -= HandleOnDiceSet;
    }


    void OnDestroy()
    {
        Debug.Log("unsign for stand still event");
        DiceStopChecker.onStill -= HandleOnDiceSet;
    }
    #endregion


    /// <summary>
    /// Handles the on dice set-Event from DiceStopChecker
    /// </summary>
    /// <param name="stoppedDice">Item display.</param>
    public void HandleOnDiceSet(DiceStopChecker stoppedDice)
    {
        string diceName = stoppedDice.DiceName;
        int diceResult = stoppedDice.DiceResult;
        int bonusMalus = DiceCreator.ConvertInFieldToInt(bonusMalusInput);
        int resultEigenschaft = 0;
        if (diceName.Contains("mut"))
        {
            int mut = DiceCreator.ConvertInFieldToInt(mutInput);
            resultEigenschaft = mut + bonusMalus;


        }
        else if (diceName.Contains("intuition"))
        {
            int intution = DiceCreator.ConvertInFieldToInt(intuituionInput);
            resultEigenschaft = intution + bonusMalus;

        }
        else if (diceName.Contains("klug"))
        {
            int klugheit = DiceCreator.ConvertInFieldToInt(klugheitInput);
            resultEigenschaft = klugheit + bonusMalus;

        }
        else if (diceName.Contains("charisma"))
        {
            int charisma = DiceCreator.ConvertInFieldToInt(charismaInput);
            resultEigenschaft = charisma + bonusMalus;

        }
        else if (diceName.Contains("ff"))
        {
            int ff = DiceCreator.ConvertInFieldToInt(fingerFertigkeitInput);
            resultEigenschaft = ff + bonusMalus;

        }
        else if (diceName.Contains("gw"))
        {
            int gw = DiceCreator.ConvertInFieldToInt(gewandtheitInput);
            resultEigenschaft = gw + bonusMalus;

        }
        else if (diceName.Contains("ko"))
        {
            int ko = DiceCreator.ConvertInFieldToInt(konstituionInput);
            resultEigenschaft = ko + bonusMalus;

        }
        else if (diceName.Contains("kk"))
        {
            int kk = DiceCreator.ConvertInFieldToInt(koerperkraftInput);
            resultEigenschaft = kk + bonusMalus;

        }

        int substract = resultEigenschaft - diceResult;

        if (substract < 0)
        {
            RESULTTHROW += substract;
        }

        throwCounter++;

        CalculateThrowResult();
    }


    private void CalculateThrowResult(){
        
        ergebnisInput.text = RESULTTHROW.ToString();
        if(throwCounter==dicePerThrow){
            RESULTTHROW = 0;
            throwCounter = 0;
        }
    }

}
