using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOpenDoor : MonoBehaviour {

    public Animator Door1;
    public Animator Door2;

    public AudioSource Door1Audio;
    public AudioSource Door2Audio;

    public GameObject AreaToHide;
    public GameObject AreaToShow;

    private bool SequenceStarted = false;


    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && SequenceStarted == false)
        {
            Debug.Log("Starting Routine");
            SequenceStarted = true;
            StartCoroutine(DoorControl());
        }
    }
    
    public IEnumerator DoorControl()
    {
        Door1.Play("DoorClose");
        Door1Audio.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        AreaToHide.SetActive(false);
        AreaToShow.SetActive(true);
        Door2.Play("DoorOpen");
        Door2Audio.GetComponent<AudioSource>().Play();
    }
}
