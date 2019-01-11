using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour {

    private bool PlayerCrouching;
	
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl) || CrouchEnforceControl.PlayerInVents == true)
        {
            PlayerCrouching = true;
        }
        else
        {
            PlayerCrouching = false;
        }


        ScalePlayer();
	}

    void ScalePlayer()
    {
        if (PlayerCrouching == true)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2.5f, 0.85f, 2.5f), Time.deltaTime * 6);
        }
        else
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2.5f,2.5f,2.5f), Time.deltaTime * 6);
        }
    }
}
