using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNormalCalculator : MonoBehaviour
{

    public static float PHI = 1 + Mathf.Sqrt(5) / 2;

    private List<Vector3> diceNomals;
    public List<Vector3> DiceNormals{
        get
        {
            return diceNomals;
        }
    }


    Vector3[] vertices = new Vector3[] {
        new Vector3(0, -1, PHI), new Vector3(0, -1, PHI), new Vector3(0, 1, -PHI),
        new Vector3(0, 1, PHI), new Vector3(-1, -PHI, 0), new Vector3(-1, PHI, 0),
        new Vector3(1, -PHI, 0), new Vector3(1, PHI, 0), new Vector3(-PHI, 0, -1),
        new Vector3(PHI, 0, -1), new Vector3(-PHI, 0, 1), new Vector3(PHI, 0, 1)
    };

    Vector3[] faces = new Vector3[] {
        new Vector3(1, 3, 11), new Vector3(1, 11, 6), new Vector3(1, 6, 4),new Vector3(1, 4, 10), new Vector3(1,10,3),
        new Vector3(3, 5, 7), new Vector3(3, 7, 11), new Vector3(3, 5, 10),new Vector3(11, 6, 9), new Vector3(11, 7, 9),
        new Vector3(0, 6, 9), new Vector3(0, 6, 4), new Vector3(0, 8, 4),new Vector3(10, 8, 4), new Vector3(10, 8, 5),
        new Vector3(2, 8, 5), new Vector3(0, 2, 9), new Vector3(0, 2, 8),new Vector3(7, 2, 9), new Vector3(5, 2, 7)
    };


	// Use this for initialization
	void Start () {
        computeNormals();
	}
	
    private void computeNormals(){
        foreach (var face in faces)
        {
            Vector3 normal = ExractNormalFromFace(face);
            diceNomals.Add(normal);

        }
    }

    private Vector3 ExractNormalFromFace(Vector3 face)
    {
        Vector3 p1 = vertices[(int)face.x];
        Vector3 p2 = vertices[(int)face.y];
        Vector3 p3 = vertices[(int)face.z];

        Vector3 normalPre = (p1 + p2 + p3) / 3;
        Vector3 normal = normalPre.normalized;
        return normal;
    }
}
