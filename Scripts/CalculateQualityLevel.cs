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

    private int resultMut, resultKlugheit, resultIntuition, resultCharisma, resultFF, resultGewandtheit, resultKonstitution, resultKoerperkraft;

    private void CalculateThrowResult(){

        ergebnisInput.text = RESULTTHROW.ToString();
        if(throwCounter==3){
            RESULTTHROW = 0;
            throwCounter = 0;
        }
    }



    public void SetResult(string name, int result){
        int bonusMalus = DiceCreator.ConvertInFieldToInt(bonusMalusInput);
        int resultEigenschaft=0;
        if(name.Contains("mut")){
            int mut = DiceCreator.ConvertInFieldToInt(mutInput);
            resultEigenschaft = mut + bonusMalus;

            
        } else if(name.Contains("intuition")){
            int intution = DiceCreator.ConvertInFieldToInt(intuituionInput);
            resultEigenschaft = intution + bonusMalus;
            
        } else if (name.Contains("klug"))
        {
            int klugheit = DiceCreator.ConvertInFieldToInt(klugheitInput);
            resultEigenschaft = klugheit + bonusMalus;

        } else if (name.Contains("charisma"))
        {
            int charisma = DiceCreator.ConvertInFieldToInt(charismaInput);
            resultEigenschaft = charisma + bonusMalus;

        } else if (name.Contains("ff"))
        {
            int ff = DiceCreator.ConvertInFieldToInt(fingerFertigkeitInput);
            resultEigenschaft = ff + bonusMalus;

        } else if (name.Contains("gw"))
        {
            int gw = DiceCreator.ConvertInFieldToInt(gewandtheitInput);
            resultEigenschaft = gw + bonusMalus;

        } else if (name.Contains("ko"))
        {
            int ko = DiceCreator.ConvertInFieldToInt(konstituionInput);
            resultEigenschaft = ko + bonusMalus;

        } else if (name.Contains("kk"))
        {
            int kk = DiceCreator.ConvertInFieldToInt(koerperkraftInput);
            resultEigenschaft = kk + bonusMalus;

        }

        int substract = resultEigenschaft - result;

        if(substract<0){
            RESULTTHROW += substract;
        }

        throwCounter++;

        CalculateThrowResult();
    }

}
