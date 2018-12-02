using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStopChecker : MonoBehaviour {
    
    private const float MAXATTEMPTS = 2;
    private const float MAX_ANGLE_DEVIATION = 5.0f;
    private int impulseCounter;
    private DiceSideUp diceSideUp;
    private CalculateQualityLevel qualityLevel;
    public Vector3 referenceUpVector;
    public float minDiffAngle;
    bool notSet = true;

    private void Start()
    {
        notSet = true;
        impulseCounter = 0;
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
            int diceResult = smallestFace + 1;
            if(smallestAngle > MAX_ANGLE_DEVIATION){
                PushDice();
            } else {
                if (notSet)
                {
                    //Hier muss das Ergebnis in die Ergebnisbox geschrieben werden
                    string diceName = gameObject.name;
                    qualityLevel.SetResult(diceName, diceResult);
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
        impulseCounter++;

    }
}
