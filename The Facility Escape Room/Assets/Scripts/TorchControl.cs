using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour {

    private bool TorchOn = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F))
           if(this.GetComponent<Light>().enabled == true)
            {
                this.GetComponent<AudioSource>().Play();
                this.GetComponent<Light>().enabled = false;
            }
        else
            {
                this.GetComponent<AudioSource>().Play();
                this.GetComponent<Light>().enabled = true;
            }
    }
}
