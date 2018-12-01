using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideUp : MonoBehaviour
{

    void Start()
    {
        // For sake of example, get number based on current orientation
        // This makes it possible to test by just rotating it in the editor and hitting play
        // Allowing 30 degrees error so will give (the side that is mostly upwards)
        // but will give -1 on "tie"

        //Debug.Log("The side world up has value: " + GetNumber(Vector3.up, 30f));
        GameObject go =GameObject.FindWithTag("plane1");
        Vector3 forward = go.transform.up;
        Debug.Log("Normale 1 " + forward);

    }

    // Gets the number of the side pointing in the same direction as the reference vector,
    // allowing epsilon degrees error.
    public int GetNumber(Vector3 referenceVectorUp, float epsilonDeg = 5f)
    {
        Vector3[] w6Normals = ToolboxDice.w6Normals;

        // here I would assert lookup is not empty, epsilon is positive and larger than smallest possible float etc
        // Transform reference up to object space
        Vector3 referenceObjectSpace = transform.InverseTransformDirection(referenceVectorUp);

        // Find smallest difference to object space direction
        float min = float.MaxValue;
        int mostSimilarDirectionIndex = -1;
        for (int side = 0; side < w6Normals.Length; side++)
        {
            float a = Vector3.Angle(referenceObjectSpace, w6Normals[side]);
            if (a <= epsilonDeg && a < min)
            {
                min = a;
                mostSimilarDirectionIndex = side;
            }
        }

        // -1 as error code for not within bounds
        return mostSimilarDirectionIndex;
    }
}