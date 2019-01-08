using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class NotepadControl : MonoBehaviour {

    public GameObject Notepad;
    public CharacterController characterController;
    public GameObject InputField;

    private bool NotepadShowing = false;
    // Update is called once per frame

    private void Start()
    {
        InputField.SetActive(false);
    }
    void Update () {
		if (Input.GetKey(KeyCode.N) && NotepadShowing == false)
        {
            characterController.enabled = false;
            characterController.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            StartCoroutine(ShowNotepad());
        }
        else if ((Input.GetKey(KeyCode.N) && NotepadShowing == true)|| (Input.GetKey(KeyCode.Escape) && NotepadShowing == true))
        {
            characterController.enabled = true;
            characterController.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            HideNotepad();
        }
    }

    public IEnumerator ShowNotepad()
    {
        NotepadShowing = true;
        for (int i = 0; i < 430; i++)
        {
            Notepad.transform.position = new Vector3(Notepad.transform.position.x-1,Notepad.transform.position.y, Notepad.transform.position.z);
            yield return new WaitForSeconds(.00000000000000000000000000000000000000000000000000000000000001f);
        }
        yield return new WaitForSeconds(.5f);
        InputField.SetActive(true);
    }

    public IEnumerator HideNotepad()
    {
        NotepadShowing = false;
        InputField.SetActive(false);
        yield return new WaitForSeconds(.2f);
        for (int i = 0; i < 430; i++)
        {
            Notepad.transform.position = new Vector3(Notepad.transform.position.x + 1, Notepad.transform.position.y, Notepad.transform.position.z);

        }
        yield return new WaitForSeconds(.2f);
    }


}
