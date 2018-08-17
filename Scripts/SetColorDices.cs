using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorDices : MonoBehaviour {

    public Dropdown colorChooser;

    public void Start()
    {   
        ToolboxDice diceVar = ToolboxDice.Instance;
        diceVar.ColorDice = ToolboxDice.BLAU_STRING_OPTION;
    }

    public void SetNewColor(){
        ToolboxDice diceVar = ToolboxDice.Instance;
        diceVar.ColorDice = colorChooser.captionText.text;
    }
}
