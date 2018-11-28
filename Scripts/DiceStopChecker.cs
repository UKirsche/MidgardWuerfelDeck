using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceStopChecker : MonoBehaviour {

    private const float MAXATTEMPTS = 2;

    private int impulseCounter;

    private void Start()
    {
        impulseCounter = 0;
    }

    void FixedUpdate()
    {
        if (IsStandStill())
        {
            Debug.Log("Würfel still");

        }
    }

    private bool IsStandStill()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if(rb.IsSleeping() && impulseCounter<MAXATTEMPTS){
            rb.AddForce(Random.onUnitSphere * 0.5f, ForceMode.Impulse);
            rb.AddTorque(Random.onUnitSphere * 0.5f, ForceMode.Impulse);
            impulseCounter++;
        }

        return false;
    }
}
