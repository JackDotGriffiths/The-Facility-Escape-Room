using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordSelector : MonoBehaviour {

    public string[] PossibleWords = new string[] {"murder","test","control","escape","puzzle","death","torture","suffering","examine","experiment","goop","eradication","trapped","danger","faint","cleanse"};

    public static string ChosenWord;

	// Use this for initialization
	void Start () {
        ChosenWord = PossibleWords[Random.Range(0, PossibleWords.Length)];
        Debug.Log("Chosen Word is " + ChosenWord);
	}
}
