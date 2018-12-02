using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideUp : MonoBehaviour
{
    private List<Vector3> normals;
    private int smallestFace;
    void Start()
    {
        DiceNormalCalculator normalCalculator = GetComponent<DiceNormalCalculator>();
        normals = normalCalculator.DiceNormals;

    }

    /// <summary>
    /// Ermittelt den kleinsten Winkels der Würfelnormalen zum ReferenceVektor aus World-Space
    /// Besser nur 1x den ReferenVektor in den ObjektSpace transformieren, als jeden Normalenvektor
    /// in den Weltspace
    /// </summary>
    /// <returns>The closest angle.</returns>
    /// <param name="referenceVectorUp">Reference vector up.</param>
    /// <param name="epsilonDeg">Epsilon deg.</param>
    public float GetClosestAngle(Vector3 referenceVectorUp, float epsilonDeg = 5f){
        
        // here I would assert lookup is not empty, epsilon is positive and larger than smallest possible float etc
        // Transform reference up to object space
        Vector3 referenceObjectSpace = transform.InverseTransformDirection(referenceVectorUp);

        // Find smallest difference to object space direction
        float smallestAngle = CalculateSmallestAngle(referenceObjectSpace, epsilonDeg);
        return smallestAngle;
    }


    // Gets the number of the side pointing in the same direction as the reference vector,
    // allowing epsilon degrees error.
    public int GetNumber()
    {
        return smallestFace;
    }

    private float CalculateSmallestAngle(Vector3 referenceObjectSpace, float epsilonDeg){
        // Find smallest difference to object space direction
        float minAngle = float.MaxValue;
        smallestFace = -1;
        for (int side = 0; side < normals.Count; side++)
        {
            float actAngle = Vector3.Angle(referenceObjectSpace, normals[side]);
            if (actAngle <= minAngle)
            {
                minAngle = actAngle;
                smallestFace = side;
            }
        }
        return minAngle;
    }
}