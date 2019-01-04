﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SubmitButtonControl : MonoBehaviour {

    private int[] DoorCode = new int[4];
    private int[] InputCode = new int[4];
    private bool Matches = true;

    public AudioSource AudioSource;
    public AudioClip Correct;
    public AudioClip Incorrect;
    public int CodeIndex;
    public Text InputText;

    private void Awake()
    {
        switch (CodeIndex)
        {
            case 1:
                DoorCode = CodeCreate.DoorCode1;
                break;
            case 2:
                DoorCode = CodeCreate.DoorCode2;
                break;
            case 3:
                DoorCode = CodeCreate.DoorCode3;
                break;
            case 4:
                DoorCode = CodeCreate.DoorCode4;
                break;
        }
            
    }

    public void CheckInput()
    {
        Matches = true;
        if (InputText.text.Length < 4)
        {
            ToolTipType.ToolTipText = "You need to enter 4 digits.";
            return;
        }
        if (InputText.text == "_ _ _ _")
        {
            ToolTipType.ToolTipText = "Enter the code using the keypad.";
            return;
        }

        string Input = InputText.text;
        char[] InputArray = Input.ToCharArray();

        //Set InputCode to the different values that were input.
        for (int i = 0; i < InputText.text.Length; i++)
        {
            InputCode[i] = int.Parse(InputArray[i].ToString());
        }

        Debug.Log("Input Code = " + InputCode[0] + "," + InputCode[1] + "," + InputCode[2] + "," + InputCode[3]);

        //Checking the two Arrays against eachother. 
        for (int i = 0; i< InputCode.Length; i++)
        {
            if(DoorCode[i] != InputCode[i])
            {
                Matches = false;
            }
        }


        if (Matches == true)
        {
            Debug.Log("InputMatches");
            Debug.Log("Correct Code = " + DoorCode[0] + "," + DoorCode[1] + "," + DoorCode[2] + "," + DoorCode[3]);
            InputCorrect();
        }
        else if (Matches == false)
        {
            Debug.Log("InputWrong");
            Debug.Log("Input Code = " + InputCode[0] + "," + InputCode[1] + "," + InputCode[2] + "," + InputCode[3]);
            Debug.Log("Correct Code = " + DoorCode[0] + "," + DoorCode[1] + "," + DoorCode[2] + "," + DoorCode[3]);
            InputWrong();
        }
    }
	
    void InputCorrect()
    {
        AudioSource.clip = Correct;

        AudioSource.Play();
    }
    void InputWrong()
    {
        AudioSource.clip = Incorrect;

        AudioSource.Play();
    }
}
