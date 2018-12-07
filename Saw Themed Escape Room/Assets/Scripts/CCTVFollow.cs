using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVFollow : MonoBehaviour {

    public GameObject target;
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position,target.transform.position- transform.position, Color.green);
        transform.LookAt(target.transform.position);
	}
}
