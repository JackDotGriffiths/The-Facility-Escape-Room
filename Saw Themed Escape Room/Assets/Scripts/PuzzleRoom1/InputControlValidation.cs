using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControlValidation : MonoBehaviour {

    public static bool guessed = false;

    public Text InputBox;
    public GameObject Indicator1;
    public GameObject Indicator2;
    public Material Grey;
    public Material Green;
    public Material Red;

    public AudioClip Incorrect;
    public AudioClip Correct;
    public AudioSource ResultSound;

    public GameObject InputField;
    public GameObject SubmitButton;
    public Animator DoorOpen;

    private string InputText;

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
            Indicator1.GetComponent<MeshRenderer>().material = Grey;
            Indicator2.GetComponent<MeshRenderer>().material = Green;

            Debug.Log("Play Sound");
            ResultSound.clip = Correct;
            ResultSound.Play();


            guessed = true;
            InputField.SetActive(false);
            SubmitButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DoorOpen.Play("DoorOpen");
        }
        else
        {
            Debug.Log(RandomWordSelector.ChosenWord);
            Debug.Log("Input : " + InputText);
            Debug.Log("Input WRONG");
            Indicator2.GetComponent<MeshRenderer>().material = Red;


            ResultSound.clip = Incorrect;
            ResultSound.Play();

            guessed = true;
            InputField.SetActive(false);
            SubmitButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //if correct, turn indicator green and open door.
        //if incorrect, turn indicator red. 
    }
}
