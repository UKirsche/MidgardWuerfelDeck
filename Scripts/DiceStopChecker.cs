using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStopChecker : MonoBehaviour {

    private const float MAXATTEMPTS = 2;
    private int impulseCounter;
    private DiceSideUp diceSideUp;
    public Vector3 referenceUpVector;
    public float minDiffAngle;

    private void Start()
    {
        impulseCounter = 0;
        diceSideUp = GetComponent<DiceSideUp>();
    }

    void FixedUpdate()
    {
        if (IsStandStill())
        {
            float smallestAngle = diceSideUp.GetClosestAngle(referenceUpVector, minDiffAngle);
            Debug.Log("Kleinster Winkel: " + smallestAngle);
            int smallestFace = diceSideUp.GetNumber();
            Debug.Log("Seite: " + smallestFace);
            if(impulseCounter<MAXATTEMPTS){
                //PushDice();
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
