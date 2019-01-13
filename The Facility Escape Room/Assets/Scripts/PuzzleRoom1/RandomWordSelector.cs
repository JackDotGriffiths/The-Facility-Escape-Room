using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordSelector : MonoBehaviour {

    public string[] PossibleWords = new string[] {"test","control","escape","puzzle","examine","experiment","eradication","trapped","danger","science","cleanse"};

    public static string ChosenWord;

	// Use this for initialization
	void Awake () {
        ChosenWord = PossibleWords[Random.Range(0, PossibleWords.Length)];
        Debug.Log("Chosen Word is " + ChosenWord);
	}
}
