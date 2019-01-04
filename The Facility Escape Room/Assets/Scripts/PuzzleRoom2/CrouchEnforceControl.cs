using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchEnforceControl : MonoBehaviour {

    public static bool PlayerInVents;

    private void Awake()
    {
        PlayerInVents = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInVents = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInVents = false;
        }
    }
}
