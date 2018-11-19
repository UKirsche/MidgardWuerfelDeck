using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCreatorDSA : DiceCreator
{
    
    public override void ThrowDice()
    {
        ClearMyBoard();

        //Lege Startposition der einzelnen Würfeltypen fest
        Vector3 startPositionDiceW20 = new Vector3(startPositionDice.x + xzOffsetDice, startPositionDice.y, startPositionDice.z + xzOffsetDice);

        //WürfelDeck-Gamobjekt -> parent für Würfel GameObject
        WuerfelDeck = GameObject.Find("WürfelDeck");

        //Instantiere die Würfel mit Kameras!
        InstantiateDice(startPositionDiceW20);
    }

    private void InstantiateDice(Vector3 position)
    {

        ToolboxDice diceVars = ToolboxDice.Instance;
        int anzahl = diceVars.dsaChosenPrefabs.Count;
        int count = 0;

        if (anzahl > 0)
        {
            DiceWithCam dCam;
            CreateParentGameObject();

            foreach (var prefab in diceVars.dsaChosenPrefabs)
            {
                //Erzeuge jeweils neue Kamera mit Würfel
                dCam = new DiceWithCam(WürfelTyp.w20);
                position.y += count;

                SetParentGameObject(dCam);

                dCam.dice = PhotonNetwork.Instantiate(prefab, position, Quaternion.identity, 0);

               
                //Beschleunige und rotiere den Würfel
                RotateAndAccelerate(dCam.dice);

                //Positioniere die Kamera auf Würfel
                PositionCam(dCam);

                //füge den Würfel mit Kamera der UpdateListe hinzu
                createdDiceWithCam.Add(dCam);

                //Zähle aktuelle Wüfel nach oben
                countAllDice++;

                //aktueller counter
                count++;
            }
        }
    }

    override protected void DestroyOldDice()
    {
        DestroyObject(wuerfelGO);

        if (createdDiceWithCam != null && createdDiceWithCam.Count > 0)
        {
            foreach (var dCam in createdDiceWithCam)
            {
                PhotonNetwork.Destroy(dCam.dice);
                DestroyObject(dCam.cam);
            }
        }
    }

}
