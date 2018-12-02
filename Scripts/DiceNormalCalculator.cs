using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dice normal calculator. Die Grundlage dafür ist ein Würfel, der genau auf der Kante steht.
/// 
/// </summary>
public class DiceNormalCalculator : MonoBehaviour
{
    public const float D20_START_ROTATION = -20.91f;
    public static float PHI = (1 + Mathf.Sqrt(5))/ 2;

    private List<Vector3> diceNomals=new List<Vector3>();
    public List<Vector3> DiceNormals{
        get
        {
            return diceNomals;
        }
    }


    Vector3[] vertices = new Vector3[] {
        new Vector3(0, -1, -PHI), new Vector3(0, -1, PHI), new Vector3(0, 1, -PHI),new Vector3(0, 1, PHI), 
        new Vector3(-1, -PHI, 0), new Vector3(-1, PHI, 0),new Vector3(1, -PHI, 0), new Vector3(1, PHI, 0),
        new Vector3(-PHI, 0, -1),new Vector3(PHI, 0, -1), new Vector3(-PHI, 0, 1), new Vector3(PHI, 0, 1)

    };

    Vector3[] faces = new Vector3[] { 
        new Vector3(0, 6, 4), new Vector3(3, 7, 11), new Vector3(0, 2, 8), new Vector3(1,10,3), new Vector3(1, 11, 6),
        new Vector3(10, 8, 5), new Vector3(0, 6, 9), new Vector3(5, 2, 7), new Vector3(10, 8, 4), new Vector3(7, 2, 9), 
        new Vector3(1, 4, 10), new Vector3(11, 7, 9), new Vector3(1, 6, 4), new Vector3(3, 5, 10),new Vector3(11, 6, 9),
        new Vector3(2, 8, 5), new Vector3(0, 2, 9),new Vector3(1, 3, 11),new Vector3(0, 8, 4),  new Vector3(3, 5, 7)
    };


    Vector3[] facesUnordered = new Vector3[] {
        new Vector3(1, 3, 11), new Vector3(1, 11, 6), new Vector3(1, 6, 4),new Vector3(1, 4, 10), new Vector3(1,10,3),
        new Vector3(3, 5, 7), new Vector3(3, 7, 11), new Vector3(3, 5, 10),new Vector3(11, 6, 9), new Vector3(11, 7, 9),
        new Vector3(0, 6, 9), new Vector3(0, 6, 4), new Vector3(0, 8, 4),new Vector3(10, 8, 4), new Vector3(10, 8, 5),
        new Vector3(2, 8, 5), new Vector3(0, 2, 9), new Vector3(0, 2, 8),new Vector3(7, 2, 9), new Vector3(5, 2, 7)
    };


	// Use this for initialization
	void Awake () {
        computeNormals();
	}
	
    void Start()
    {
        
    }


    private void computeNormals(){
        foreach (var face in faces)
        {
            Vector3 normal = ExractNormalFromFace(face);
            Vector3 rotatedNormal = RotateNormal(normal);
            Vector3 normalNormalized = rotatedNormal.normalized;
            diceNomals.Add(normalNormalized);

        }
    }

    private Vector3 RotateNormal(Vector3 normalUnrotated){
        Vector3 rotatedNormal =  Quaternion.Euler(D20_START_ROTATION, 0, 0) * normalUnrotated;
        return rotatedNormal;
        
    }

    private Vector3 ExractNormalFromFace(Vector3 face)
    {
        Vector3 p1 = vertices[(int)face.x];
        Vector3 p2 = vertices[(int)face.y];
        Vector3 p3 = vertices[(int)face.z];

        Vector3 normalPre = (p1 + p2 + p3) / 3;
        return normalPre;
    }
}
