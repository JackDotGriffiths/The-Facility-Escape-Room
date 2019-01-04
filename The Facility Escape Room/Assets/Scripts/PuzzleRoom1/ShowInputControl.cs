using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;
using UnityEngine;

public class ShowInputControl : MonoBehaviour {

    private bool ShowingInput;
    private bool InCollider = false;

    public GameObject InputField;
    public GameObject SubmitButton;
    public CharacterController characterController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
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

    private void Start()
    {
        ShowingInput = false;
    }

    void Update () {
		if (ObjectDetection.LookAtObject == "Plynth" && Input.GetKeyDown(KeyCode.E) && ShowingInput == false && InCollider == true && InputControlValidation.guessed == false)
        {
            characterController.enabled = false;
            characterController.GetComponent<FirstPersonController>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            InputField.SetActive(true);
            SubmitButton.SetActive(true);
            ShowingInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            InputField.SetActive(false);
            SubmitButton.SetActive(false);
            ShowingInput = false;
        }
	}
}
