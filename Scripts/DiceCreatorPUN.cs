using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCreatorPUN : DiceCreator
{

	override protected void InstantiateDice (WürfelTyp typ, Vector3 position, int anzahl){
		
		if (anzahl > 0) {
			DiceWithCam dCam;
			CreateParentGameObject ();

			for (int count = 0; count < anzahl; count++) {
				//Erzeuge jeweils neue Kamera mit Würfel
				dCam = new DiceWithCam (typ);
				position.y += count;

				SetParentGameObject (dCam);

				switch (typ) {
				case WürfelTyp.w6:
					if (count % 2 == 0) {
						dCam.dice = PhotonNetwork.Instantiate ("d6black", position, Quaternion.identity, 0);
					} else {
						dCam.dice = PhotonNetwork.Instantiate ("d6blue", position, Quaternion.identity, 0);
					}

					dCam.dice.name = "W6_" + count;
					break;
				case WürfelTyp.w10:
					if (count % 2 == 0) {
						dCam.dice = PhotonNetwork.Instantiate ("d10black", position, Quaternion.identity, 0);
					} else {
						dCam.dice = PhotonNetwork.Instantiate ("d10blue", position, Quaternion.identity, 0);
					}
					dCam.dice.name = "W10_" + count;
					break;
				case WürfelTyp.w20:
					if (count % 2 == 0) {
						dCam.dice = PhotonNetwork.Instantiate ("d20black", position, Quaternion.identity, 0);
					} else {
						dCam.dice = PhotonNetwork.Instantiate ("d20blue", position, Quaternion.identity, 0);
					}
					dCam.dice.name = "W20_" + count;
					break;
				default:
					break;
				}

				//Beschleunige und rotiere den Würfel
				RotateAndAccelerate (dCam.dice);

				//Positioniere die Kamera auf Würfel
				PositionCam (dCam);

				//füge den Würfel mit Kamera der UpdateListe hinzu
				createdDiceWithCam.Add (dCam);

				//Zähle aktuelle Wüfel nach oben
				countAllDice++;
			}
		}
	}

	override protected void DestroyOldDice()
	{
		DestroyObject(wuerfelGO);

		if(createdDiceWithCam!=null && createdDiceWithCam.Count > 0)
		{
			foreach (var dCam in createdDiceWithCam)
			{
				PhotonNetwork.Destroy(dCam.dice);
				DestroyObject(dCam.cam);
			}
		}
	}

}
