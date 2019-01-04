using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour {

    private bool ShowingInput;
    private bool InCollider = false;

    public GameObject InputKeypadUI;

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

    private void Start()
    {
        ShowingInput = false;
    }

    void Update()
    {
        if (ObjectDetection.LookAtObject == this.name && Input.GetKeyDown(KeyCode.E) && ShowingInput == false && InCollider == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            characterController.enabled = false;
            characterController.GetComponent<FirstPersonController>().enabled = false;


            InputKeypadUI.SetActive(true);
            ShowingInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;


            InputKeypadUI.SetActive(false);
            ShowingInput = false;
        }
    }
}
