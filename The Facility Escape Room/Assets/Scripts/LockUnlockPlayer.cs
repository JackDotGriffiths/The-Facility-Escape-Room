using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LockUnlockPlayer : MonoBehaviour {

    public static CharacterController characterController;
    public CharacterController Player;

    private void Awake()
    {
        characterController = Player;
    }


    public static void LockPlayer()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        characterController.enabled = false;
        characterController.GetComponent<FirstPersonController>().enabled = false;
    }

    public static void UnlockPlayer()
    {
        Debug.Log("Unlocking Player");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController.enabled = true;
        characterController.GetComponent<FirstPersonController>().enabled = true;
    }
}
