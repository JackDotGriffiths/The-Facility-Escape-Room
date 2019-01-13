using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EscapeEntranceControl : MonoBehaviour {

    public GameObject Player;
    public static CharacterController characterController;

    public GameObject DoorToClose;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;

    public Material LightOn;
    public Material LightOff;

    public AudioSource Entity;
    public AudioClip Breathing;
    public AudioClip Punch;

    public GameObject NewSpawnPoint;

    public string Message1;
    public string Message2;

    private bool PlayedSequence = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && PlayedSequence == false)
        {
            PlayedSequence = true;
            StartCoroutine(RunSequence());
        }
    }

    IEnumerator RunSequence()
    {
        //Close Door Behind  the Player
        DoorToClose.GetComponent<Animator>().Play("DoorClose");
        DoorToClose.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        
        //Run Welcome message 1
        ToolTipType.CreateTooltip(Message1);
        yield return new WaitForSeconds(6f);

        //Turn off Lights
        TurnOffLight(Light1);
        yield return new WaitForSeconds(3f);
        TurnOffLight(Light2);
        yield return new WaitForSeconds(2f);
        TurnOffLight(Light3);
        yield return new WaitForSeconds(2f);
        TurnOffLight(Light4);
        yield return new WaitForSeconds(4f);
        TurnOffLight(Light5);
        yield return new WaitForSeconds(2f);

        //Slowly hear breathing.
        Entity.volume = 0;
        Entity.clip = Breathing;
        Entity.loop = true;
        Entity.Play();
        for(int i=0; i < 100; i++)
        {
            Entity.volume += 0.005f;
            yield return new WaitForSeconds(0.05f);
        }

        //Punch the Player
        yield return new WaitForSeconds(3f);

        LockUnlockPlayer.LockPlayer();
        Entity.volume = 0.8f;
        Entity.clip = Punch;
        Entity.loop = false;
        Entity.Play();
        yield return new WaitForSeconds(0.1f);
        Entity.volume = 0;

        //Screen Go Black.
        FadeScreenControl.Toggle();
        Player.GetComponentInChildren<AudioListener>().enabled = false;
        yield return new WaitForSeconds(2);
        ToolTipType.CreateTooltip("Welcome to The Facility.");

        yield return new WaitForSeconds(6);
        LockUnlockPlayer.UnlockPlayer();
        Player.transform.position = NewSpawnPoint.transform.position;
        Player.GetComponentInChildren<AudioListener>().enabled = true;
        FadeScreenControl.Toggle();

        TurnOnLight(Light1);
        TurnOnLight(Light2);
        TurnOnLight(Light3);
        TurnOnLight(Light4);
        TurnOnLight(Light5);





    }

    void TurnOffLight(GameObject light)
    {
        light.GetComponent<AudioSource>().Play();
        light.GetComponent<MeshRenderer>().material = LightOff;
        light.GetComponentInChildren<Light>().enabled = false;
    }
    void TurnOnLight(GameObject light)
    {
        light.GetComponent<MeshRenderer>().material = LightOn;
        light.GetComponentInChildren<Light>().enabled = true;
    }
}
