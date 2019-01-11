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
		if (Input.GetKeyDown(KeyCode.E) && ShowingInput == false && InCollider == true && InputControlValidation.guessed == false)
        {
            LockUnlockPlayer.LockPlayer();

            InputField.SetActive(true);
            SubmitButton.SetActive(true);
            ShowingInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && InputField.activeInHierarchy == true && SubmitButton.activeInHierarchy == true)
        {
            LockUnlockPlayer.UnlockPlayer();

            InputField.SetActive(false);
            SubmitButton.SetActive(false);
            ShowingInput = false;
        }
	}
}
