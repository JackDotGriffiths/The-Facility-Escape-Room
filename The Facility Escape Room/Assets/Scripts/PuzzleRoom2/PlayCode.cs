using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCode : MonoBehaviour
{

    private bool InCollider;
    private int[] Array;
    private AudioClip[] NoteArray;
    private bool TuneStopped = true;
    private AudioSource Speaker;

    public AudioClip Note1;
    public AudioClip Note2;
    public AudioClip Note3;
    public AudioClip Note4;
    public AudioClip Note5;
    public AudioClip Note6;
    public AudioClip Note7;
    public AudioClip Note8;
    public AudioClip Note9;

    public int CodeIndex;
    public Text CodeOutput;


    private void Awake()
    {
        TuneStopped = true;
        InCollider = false;
        Invoke("AssignTune", 2f);
        Speaker = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InCollider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InCollider = false;
        }
    }
    void Update()
    {
        string ObjectName = "PlaySignal" + CodeIndex;
        if (ObjectDetection.LookAtObject == ObjectName && Input.GetKeyDown(KeyCode.E) && InCollider == true && TuneStopped == true)
        {
            TuneStopped = false;
            StartCoroutine(playAudioClips());
        }

    }

    void AssignTune()
    {
        if (CodeIndex == 1)
        {
            Array = CodeCreate.DoorCode1;
        }
        else if (CodeIndex == 2)
        {
            Array = CodeCreate.DoorCode2;
        }
        else if (CodeIndex == 3)
        {
            Array = CodeCreate.DoorCode3;
        }
        else if (CodeIndex == 4)
        {
            Array = CodeCreate.DoorCode4;
        }


        NoteArray = new AudioClip[Array.Length];

        for (int i = 0; i < Array.Length; i++)
        {
            switch (Array[i])
            {
                case (1):
                    NoteArray[i] = Note1;
                    break;

                case (2):
                    NoteArray[i] = Note2;
                    break;

                case (3):
                    NoteArray[i] = Note3;
                    break;

                case (4):
                    NoteArray[i] = Note4;
                    break;

                case (5):
                    NoteArray[i] = Note5;
                    break;

                case (6):
                    NoteArray[i] = Note6;
                    break;

                case (7):
                    NoteArray[i] = Note7;
                    break;

                case (8):
                    NoteArray[i] = Note8;
                    break;

                case (9):
                    NoteArray[i] = Note9;
                    break;
            }

        }
    }


    IEnumerator playAudioClips()
    {
        yield return null;

        for(int i = 0; i < NoteArray.Length; i++)
        {
            CodeOutput.text = Array[i].ToString(); ;
            Speaker.clip = NoteArray[i];
            Speaker.Play();
            while (Speaker.isPlaying)
            {
                yield return null;
            }
            CodeOutput.text = "";
        }
        TuneStopped = true;
        CodeOutput.text = "<>";

    }
}

