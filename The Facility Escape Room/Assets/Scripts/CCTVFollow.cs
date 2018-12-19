using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVFollow : MonoBehaviour {

    public GameObject target;
	
	// Update is called once per frame
	void Update () {
        
        //Retrieve the Distance of the camera from the player.
        float DistancefromPlayer = Vector3.Distance(transform.position, target.transform.position);

        //If the Distance is less than 15, Look Directly at the player.
        if (DistancefromPlayer <= 20)
        {
            Quaternion targetRot = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRot,5f * Time.deltaTime);
        }
        else
        {

        }
	}
}
