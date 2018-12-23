using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour {

    private bool PlayerCrouching;
	
	void Update () {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("PlayerCrouch");
            PlayerCrouching = true;
        }
        else
        {
            Debug.Log("PlayerStand");
            PlayerCrouching = false;
        }


        ScalePlayer();
	}

    void ScalePlayer()
    {
        if (PlayerCrouching == true)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.7f, 0.85f, 1.7f), Time.deltaTime * 6);
        }
        else
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.7f,1.7f,1.7f), Time.deltaTime * 6);
        }
    }
}
