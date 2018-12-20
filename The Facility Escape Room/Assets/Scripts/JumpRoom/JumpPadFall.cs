using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadFall : MonoBehaviour {

    public GameObject splashEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("TurnOffConstraints", 1.5f);
        }
        if (other.tag == "Water")
        {
            Splash();
        }
    }

    private void TurnOffConstraints()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void Splash()
    {
        GameObject SplashInstance = (GameObject)Instantiate(splashEvent, transform.position, new Quaternion());
        Destroy(SplashInstance, 2.5f);
        Destroy(this.gameObject);
    }
}
