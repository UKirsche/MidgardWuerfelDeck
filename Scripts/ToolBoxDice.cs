using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class ToolboxDice : Singleton<ToolboxDice>
{
    public const string BLAU_STRING_OPTION = "Blau";

    public const string BLAU_D6_PREFAB = "d6blue";
    public const string BLAU_D10_PREFAB = "d10blue";
    public const string BLAU_D20_PREFAB = "d20blue";
    public const string RED_STRING_OPTION = "Rot";
    public const string RED_D6_PREFAB = "d6red";
    public const string RED_D10_PREFAB = "d10red";
    public const string RED_D20_PREFAB = "d20red";
    public const string GREEN_STRING_OPTION = "Grün";
    public const string GREEN_D6_PREFAB = "d6green";
    public const string GREEN_D10_PREFAB = "d10green";
    public const string GREEN_D20_PREFAB = "d20green";
    public const string MASTER_STRING_OPTION  = "Meisterle";
    public const string MASTER_D6_PREFAB = "d6master";
    public const string MASTER_D10_PREFAB = "d10master";
    public const string MASTER_D20_PREFAB = "d20master";
    public  string colorDice_d6, colorDice_d10, colorDice_d20;

    #region DSA Würfel
    public const string DSA_D20_PREFAB_NAME_MUT = "d20mut";
    public const string DSA_D20_PREFAB_NAME_KLUG = "d20klug";
    public const string DSA_D20_PREFAB_NAME_INTUITION = "d20intuition";
    public const string DSA_D20_PREFAB_NAME_CHARISMA = "d20charisma";
    public const string DSA_D20_PREFAB_NAME_FF = "d20ff";
    public const string DSA_D20_PREFAB_NAME_GW = "d20gw";
    public const string DSA_D20_PREFAB_NAME_KO = "d20ko";
    public const string DSA_D20_PREFAB_NAME_KK = "d20kk";
    public string prefabNameDSA_d20_1, prefabNameDSA_d20_2, prefabNameDSA_d20_3;
    #endregion



    protected ToolboxDice() {} // guarantee this will be always a singleton only - can't use the constructor!

    private string colorDice;
    public string ColorDice {
        get { return colorDice; }
        set {
            colorDice = value;
            if(value.Equals(BLAU_STRING_OPTION)){
                colorDice_d6 = BLAU_D6_PREFAB; 
                colorDice_d10 = BLAU_D10_PREFAB;
                colorDice_d20 = BLAU_D20_PREFAB;
            } else if (value.Equals(RED_STRING_OPTION)){
                colorDice_d6 = RED_D6_PREFAB;
                colorDice_d10 = RED_D10_PREFAB;
                colorDice_d20 = RED_D20_PREFAB;
            } else if (value.Equals(GREEN_STRING_OPTION)){
                colorDice_d6 = GREEN_D6_PREFAB;
                colorDice_d10 = GREEN_D10_PREFAB;
                colorDice_d20 = GREEN_D20_PREFAB;
            } else if (value.Equals(MASTER_STRING_OPTION)){
                colorDice_d6 = MASTER_D6_PREFAB;
                colorDice_d10 = MASTER_D10_PREFAB;
                colorDice_d20 = MASTER_D20_PREFAB;
            } 
        }
    }


    public List<String> dsaChosenPrefabs = new List<string>();
    public Dictionary<String, int> diceChosen = new Dictionary<string, int>();


}