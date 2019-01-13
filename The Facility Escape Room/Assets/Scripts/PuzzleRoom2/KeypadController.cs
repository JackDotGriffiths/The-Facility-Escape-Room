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

    private void Awake()
    {
        ShowingInput = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ShowingInput == false && InCollider == true)
        {
            LockUnlockPlayer.LockPlayer();


            InputKeypadUI.SetActive(true);
            ShowingInput = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && InputKeypadUI.activeInHierarchy == true)
        {
            LockUnlockPlayer.UnlockPlayer();


            InputKeypadUI.SetActive(false);
            ShowingInput = false;
        }
    }
}
