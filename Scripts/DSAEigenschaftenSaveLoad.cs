using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DSAEigenschaftenSaveLoad : MonoBehaviour {

    public InputField mut, klugheit, intuition, charisma, ff, gewandtheit, ko, kk;
    private DSAEigenschaften mCharacter;
    private ToolboxDice diceVars;

	// Use this for initialization
	void Start () {
        diceVars = ToolboxDice.Instance;
        mCharacter = diceVars.mCharacter;
        LoadEigenschaften();
	}

    public void SaveEigenschaften(){
        InputFieldsToEigenschaften();
        DSAEigenschaftenSerializer.Save(mCharacter);
    }

    public void LoadEigenschaften(){
        DSAEigenschaftenSerializer.Load();
        mCharacter = DSAEigenschaftenSerializer.dsaCharacter;
        EigenschaftenToInputFields();
    }

    private void InputFieldsToEigenschaften(){
        mCharacter.mut = DiceCreator.ConvertInFieldToInt(mut);
        mCharacter.intution = DiceCreator.ConvertInFieldToInt(intuition);
        mCharacter.klugheit = DiceCreator.ConvertInFieldToInt(klugheit);
        mCharacter.charisma = DiceCreator.ConvertInFieldToInt(charisma);
        mCharacter.fingerfertigkeit = DiceCreator.ConvertInFieldToInt(ff);
        mCharacter.gewandtheit = DiceCreator.ConvertInFieldToInt(gewandtheit);
        mCharacter.konstitution = DiceCreator.ConvertInFieldToInt(ko);
        mCharacter.koerperkaft = DiceCreator.ConvertInFieldToInt(kk);
    }

    private void EigenschaftenToInputFields()
    {
        mut.text = mCharacter.mut.ToString();
        klugheit.text = mCharacter.klugheit.ToString();
        intuition.text = mCharacter.intution.ToString();
        charisma.text = mCharacter.charisma.ToString();
        ff.text = mCharacter.fingerfertigkeit.ToString();
        gewandtheit.text = mCharacter.gewandtheit.ToString();
        ko.text = mCharacter.konstitution.ToString();
        kk.text = mCharacter.koerperkaft.ToString();

    }
}
