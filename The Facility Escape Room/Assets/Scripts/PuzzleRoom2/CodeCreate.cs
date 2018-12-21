using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCreate : MonoBehaviour
{
    public static int[] DoorCode1 = new int[4];
    public static int[] DoorCode2 = new int[5];
    public static int[] DoorCode3 = new int[6];
    public static int[] DoorCode4 = new int[7];


    private void Awake()
    {
        GenerateDoorCodes(DoorCode1);
        GenerateDoorCodes(DoorCode2);
        GenerateDoorCodes(DoorCode3);
        GenerateDoorCodes(DoorCode4);
        Debug.Log(DoorCode1[0] + "," + DoorCode1[1] + "," + DoorCode1[2] + "," + DoorCode1[3]);
        Debug.Log(DoorCode2[0] + "," + DoorCode2[1] + "," + DoorCode2[2] + "," + DoorCode2[3] + "," + DoorCode2[4]);

    }

    private void GenerateDoorCodes(int[] array)
    {
        for (int i = 0; i < array.Length ; i++)
        {
            int RandomNo = Random.Range(1, 4);
            if (i > 0 && RandomNo == array[i-1])
            {
                RandomNo += 1;
            }
            array[i] = RandomNo;
        }
    }
}
