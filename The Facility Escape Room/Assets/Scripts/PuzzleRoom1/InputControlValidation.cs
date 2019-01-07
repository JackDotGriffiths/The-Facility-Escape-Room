using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InputControlValidation : MonoBehaviour {

    public static bool guessed;

    public Text InputBox;

    public AudioClip Incorrect;
    public AudioClip Correct;
    public AudioSource ResultSound;

    public GameObject InputField;
    public GameObject SubmitButton;
    public GameObject ExitDoor;


    private string InputText;
    public CharacterController characterController;

    public void Awake()
    {
        guessed = false;
    }

    public void Update()
    {
        InputText = InputBox.text;
    }

    public void ButtonPress()
    {
        //Check the input text
        string CorrectText = RandomWordSelector.ChosenWord;

        if(InputText.ToLower() == "")
        {
            ResultSound.clip = Incorrect;
            ResultSound.Play();
        }
        else if(InputText.ToLower() == CorrectText)
        {
            Debug.Log(RandomWordSelector.ChosenWord);
            Debug.Log("Input : " + InputText);
            Debug.Log("Input Correct");

            Debug.Log("Play Sound");
            ResultSound.clip = Correct;
            ResultSound.Play();


            guessed = true;
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            InputField.SetActive(false);
            SubmitButton.SetActive(false);
            ExitDoor.GetComponent<Animator>().Play("DoorOpen");
            ExitDoor.GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log(RandomWordSelector.ChosenWord);
            Debug.Log("Input : " + InputText);
            Debug.Log("Input WRONG");


            ResultSound.clip = Incorrect;
            ResultSound.Play();

            guessed = true;
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            InputField.SetActive(false);
            SubmitButton.SetActive(false);
        }
        //if correct, turn indicator green and open door.
        //if incorrect, turn indicator red. 
    }
}
