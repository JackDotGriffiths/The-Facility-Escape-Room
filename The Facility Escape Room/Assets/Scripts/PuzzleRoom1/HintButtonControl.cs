using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButtonControl : MonoBehaviour {

    private bool InCollider = false;
    private int HintLetter;
    private int HintCounter = 0;

    public AudioSource audioSource;
    public AudioClip getHint;
    public AudioClip blockHint;

    public GameObject HintDisplay;

    private void Awake()
    {
        InCollider = false;
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
        if (ObjectDetection.LookAtObject == "HintPlynth" && Input.GetKeyDown(KeyCode.E) && InCollider == true)
        {
            if (HintCounter < 3)
            {
                Text Output = HintDisplay.GetComponent<Text>();
                HintLetter = Random.Range(0, RandomWordSelector.ChosenWord.Length);

                int HintIndex = HintLetter + 1;
                string Suffix; 
                if (HintIndex == 1)
                {
                    Suffix = "st";
                }
                else  if (HintIndex == 2)
                {
                    Suffix = "nd";
                }
                else if (HintIndex == 3)
                {
                    Suffix = "rd";
                }
                else
                {
                    Suffix = "th";
                }


                Output.text = ("The " + HintIndex + Suffix + " letter in the answer is: " + RandomWordSelector.ChosenWord[HintLetter]);
                HintCounter += 1;
                audioSource.clip = getHint;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = blockHint;
                audioSource.Play();
            }
        }
    }
}
