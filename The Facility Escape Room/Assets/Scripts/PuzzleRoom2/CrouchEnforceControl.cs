using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchEnforceControl : MonoBehaviour {

    public static bool PlayerInVents;
    public bool PlayerCrouched = false;
    public GameObject Player;

    private void Awake()
    {
        PlayerInVents = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInVents = true;
            Player.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.5f, 0.6f, 1.5f), Time.deltaTime * 6);

            Player.GetComponent<AudioSource>().pitch = 1.25f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerInVents = false;
        Player.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2.5f, 2.5f, 2.5f), Time.deltaTime * 6);
        Player.GetComponent<AudioSource>().pitch = 1f;
    }



}
