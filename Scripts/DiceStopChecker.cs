using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStopChecker : MonoBehaviour {
    
    private const float MAX_ANGLE_DEVIATION = 5.0f;
    private DiceSideUp diceSideUp;
    private CalculateQualityLevel qualityLevel;
    public Vector3 referenceUpVector;
    public float minDiffAngle;
    bool notSet = true;
    private string diceName;

    #region Event-Delegate sobald Würfel still steht
    public delegate void DiceStandStillDelegate(DiceStopChecker item);
    public static event DiceStandStillDelegate onStill;
    #endregion

    #region Für Abfrage von Ergebnis und Namen
    public string DiceName { 
        get { return diceName; } 
    }

    private int diceResult;
    public int DiceResult{
        get { return diceResult ; } 
    }
    #endregion

    private void Start()
    {
        diceName = gameObject.name;
        notSet = true;
        diceSideUp = GetComponent<DiceSideUp>();
        GameObject goQuality = GameObject.Find("PanelEigenschaften");
        qualityLevel = goQuality.GetComponent<CalculateQualityLevel>();
    }

    void FixedUpdate()
    {
        if (IsStandStill())
        {
            float smallestAngle = diceSideUp.GetClosestAngle(referenceUpVector, minDiffAngle);
            int smallestFace = diceSideUp.GetNumber();
            diceResult = smallestFace + 1;
            if(smallestAngle > MAX_ANGLE_DEVIATION){
                PushDice();
            } else {
                if (notSet)
                {
                    //Hier muss das Ergebnis in die Ergebnisbox geschrieben werden
                    //FIXME Rufe event hier auf
                    if (onStill != null && this != null)
                    {
                        onStill.Invoke(this);
                    }
                    Debug.Log("Würfel " + diceName + " steht still");
                    notSet = false;
                }
            }

           

        } 
    }

    private bool IsStandStill()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if(rb.IsSleeping()){
            return true;
        }
        return false;
    }

    private void PushDice(){
        
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(Random.onUnitSphere * 0.5f, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * 0.5f, ForceMode.Impulse);

    }
}
