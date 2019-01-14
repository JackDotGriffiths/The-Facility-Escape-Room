using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequencePlaying : MonoBehaviour {

    public static bool PlayerInArea;
    public static bool CompletedPuzzle;

    private void Awake()
    {
        CompletedPuzzle = false;
        PlayerInArea = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerInArea = true;
        }
    }
}
