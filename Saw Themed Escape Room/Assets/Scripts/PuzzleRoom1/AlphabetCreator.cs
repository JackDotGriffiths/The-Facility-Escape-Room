using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlphabetCreator : MonoBehaviour {

    public static int StartValue;
    public Text DisplayCodedWordText;


    private string[,] AlphabetCoded = new string[26,26];
    private string[] Alphabet = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    private string[] CodedWord;
    private string TextToDisplay;




    // Use this for initialization
    void Start () {
        StartValue = Random.Range(20, 200);
        Debug.Log("Start Value is " + StartValue);
        CreateAlphabetArrays();
        
	}
	
    void CreateAlphabetArrays()
    {
        //Creates an array of each letter and the corresponding Value after it.
        for(int i = 0; i < 26; i++)
        {
            AlphabetCoded[i, 0] = Alphabet[i];
            AlphabetCoded[i, 1] = (StartValue + i).ToString();
            //Debug.Log(AlphabetCoded[i, 0] + "," + AlphabetCoded[i, 1]);
        }
        Invoke("ConvertChosenWord", 1f);      
    }

    void ConvertChosenWord()
    {
        string TargetLetter;
        CodedWord = new string[RandomWordSelector.ChosenWord.Length];
        //For each Character in Chosen Word:
        for(int i = 0; i < RandomWordSelector.ChosenWord.Length; i++)
        {
            TargetLetter = RandomWordSelector.ChosenWord[i].ToString();
            //Search for it in AlphabetCoded until you find it, then add the corresponding Number to CodedWord.
            for (int x = 0; x < 26; x++)
            {
                if (AlphabetCoded[x,0] == TargetLetter)
                {
                    CodedWord[i] = AlphabetCoded[x, 1];
                }
            }
        }

        //This gives us Coded Word - an Array of values that correspond to the matching letters of Chosen Word.
        DisplayCodedWord();
    }

    void DisplayCodedWord()
    {
        for (int i = 0; i < CodedWord.Length; i++)
        {
            if (i == 0)
            {
                TextToDisplay = CodedWord[i];
            }
            else
            {
                TextToDisplay += " - " + CodedWord[i];
            }
        }

        DisplayCodedWordText.text = TextToDisplay;
    }
    
}
