using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class KeypadButton : MonoBehaviour {

    public Text KeypadInput;
    public int Value;

    public CharacterController characterController;

    // Use this for initialization
    void Start () {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();

        characterController.enabled = false;
        characterController.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        Value = int.Parse(this.gameObject.name);
	}
	
	// Update is called once per frame
	public void ButtonClick() {
        if (KeypadInput.text == "_ _ _ _")
        {
            KeypadInput.text = "";
        }
        if (KeypadInput.text.Length < 4)
        {
            string OldText = KeypadInput.text;
            string NewText = KeypadInput.text + Value.ToString();
            KeypadInput.text = NewText;
        }
        else
        {
            return;
        }
	}
}
