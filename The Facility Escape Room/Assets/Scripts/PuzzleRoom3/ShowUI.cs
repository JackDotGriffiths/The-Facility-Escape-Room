using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowUI : MonoBehaviour {


    private bool ShowingInput = false;
    private bool InCollider = false;

    public GameObject SimonSaysUI;
    public CharacterController characterController;

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
        if (Input.GetKeyDown(KeyCode.E) && ShowingInput == false && InCollider == true && PuzzleControl.AwaitingInput == true && PuzzleControl.CodePlaying != true)
        {
            characterController.enabled = false;
            characterController.GetComponent<FirstPersonController>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            SimonSaysUI.SetActive(true);

            ShowingInput = true;
        }
        if (PuzzleControl.AwaitingInput == false)
        {
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            SimonSaysUI.SetActive(false); 


            ShowingInput = false;
        }
    }
}
