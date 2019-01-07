using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysCanvasControl : MonoBehaviour {

    public static int[] ExpectedCode;
    public static int[] GivenCode;
    public static bool RegenCodes = false;

    public AudioClip correct;
    public AudioClip incorrect;

    private bool GivenCodeReset = false;
    private int CorrectCount;
    private int ExpectedCorrectCount;
    private int GivenCodeCurrentIndex = 0;

    public static bool PlayNextClip;
    public static bool RestartGame;
    public AudioSource AudioSource;


    private void ResetGivenCode()
    {
        for(int i=0; i < ExpectedCode.Length; i++)
        {
            GivenCode[i] = 0;
        }
    }
    private void Update()
    {
        if (PuzzleControl.AwaitingInput == true)
        {
            ExpectedCode = PuzzleControl.CurrentlyActiveCode;
            if (GivenCodeReset == false)
            {
                GivenCode = new int[ExpectedCode.Length];
                GivenCodeReset = true;
            }

            if (ExpectedCode != null)
            {
                CheckInput();
            }
        }
    }

    private void CheckInput()
    {
        ExpectedCorrectCount = ExpectedCode.Length;
        for (int i = 0; i < ExpectedCode.Length; i++)
        {
            if (GivenCode[i] == 0)
            {
                return;
            }
            else if (GivenCode[i] != ExpectedCode[i])
            {
                Debug.Log("Incorrect");
                AudioSource.clip = incorrect;
                AudioSource.Play();
                PuzzleControl.AwaitingInput = false;
                GivenCodeCurrentIndex = 0;
                PuzzleControl.CodeIndex = 1;
                RestartGame = true;
                GivenCodeReset = false;
                return;
                //INCORRECT - RESTART

            }
            else if (GivenCode[i] == ExpectedCode[i] && CorrectCount < ExpectedCorrectCount)
            {
                CorrectCount += 1;
            }
        }

        Debug.Log(CorrectCount + " = Correct Count");
        Debug.Log(ExpectedCorrectCount + " Expected");
        if (CorrectCount == ExpectedCorrectCount)
        {
            AudioSource.clip = correct;
            AudioSource.Play();
            GivenCodeReset = false;
            PuzzleControl.AwaitingInput = false;
            GivenCodeCurrentIndex = 0;
            PlayNextClip = true;
            return;
            //CORRECT CODE - PLAY NEXT CODE
}
    }

    public void ButtonPress(int Value)
    {
        GivenCode[GivenCodeCurrentIndex] = Value;
        GivenCodeCurrentIndex += 1;
    }
}
