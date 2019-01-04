using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVentsControl : MonoBehaviour {

    private bool PlayerInCollider = false;
    private bool Moved = false;
    public BoxCollider ToDelete;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerInCollider = true;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInCollider = false;
        }
    }

    private void Update()
    {
        if (PlayerInCollider == true && Input.GetKey(KeyCode.E) && Moved == false )
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().AddForce(transform.up * 700f);
            this.GetComponent<Rigidbody>().AddForce(transform.forward * 80f);
            this.GetComponent<Rigidbody>().AddForce(transform.right * 40f);
            Moved = true;
            Invoke("DeleteCollider", 10f);
        }   
    }

    void DeleteCollider()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        ToDelete.enabled = false;
    }
}
