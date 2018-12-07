using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour {

    public static string LookAtObject;
	
	// Update is called once per frame
	void Update () {
        //Cast a Ray from CameraPos forward by 2 Units
        Debug.DrawRay(transform.position, transform.forward * 4f,Color.red);
        RaycastHit hitPoint;
        if (Physics.Raycast(transform.position,transform.forward,out hitPoint, 4f))
        {
            //Set LookAtObject to the name of the object the player is looking at. This will be helpful for pressing buttons/moving objects for puzzles.
            LookAtObject = hitPoint.collider.gameObject.name;
        }
	}
}
