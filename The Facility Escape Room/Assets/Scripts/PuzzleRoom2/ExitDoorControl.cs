using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorControl : MonoBehaviour {

    public static int DoorCorrectCount = 0;

    public MeshRenderer RedKeypadIndicator;
    public MeshRenderer GreenKeypadIndicator;
    public MeshRenderer BlueKeypadIndicator;
    public MeshRenderer YellowKeypadIndicator;

    public Material CodeCorrectMaterial;

    private bool DoorOpened = false;


	// Update is called once per frame
	void Update () {
		if (DoorCorrectCount == 4 && DoorOpened == false)
        {
            DoorOpened = true;
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        this.GetComponent<Animator>().Play("DoorOpen");
        this.GetComponent<AudioSource>().Play();
    }
}
