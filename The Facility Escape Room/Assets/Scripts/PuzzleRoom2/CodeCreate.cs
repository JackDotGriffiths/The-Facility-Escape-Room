using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCreate : MonoBehaviour
{
    public static int[] DoorCode1 = new int[4];
    public static int[] DoorCode2 = new int[4];
    public static int[] DoorCode3 = new int[4];
    public static int[] DoorCode4 = new int[4];



    private void Awake()
    {
        GenerateDoorCodes(DoorCode1);
        GenerateDoorCodes(DoorCode2);
        GenerateDoorCodes(DoorCode3);
        GenerateDoorCodes(DoorCode4);

    }

    private void GenerateDoorCodes(int[] array)
    {
        for (int i = 0; i < array.Length ; i++)
        {
            int RandomNo = Random.Range(1, 9);
            if (i > 0 && RandomNo == array[i-1])
            {
                RandomNo += 1;
            }
            array[i] = RandomNo;
        }
    }
}
