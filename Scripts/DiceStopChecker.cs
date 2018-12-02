using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStopChecker : MonoBehaviour {
    
    private const float MAXATTEMPTS = 2;
    private const float MAX_ANGLE_DEVIATION = 5.0f;
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
            int smallestFace = diceSideUp.GetNumber();
            if(smallestAngle > MAX_ANGLE_DEVIATION){
                PushDice();
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
