using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintLetterDisplay : MonoBehaviour {

    private int HintLetter;
	
	// Update is called once per frame
	void Start () {
        Invoke("ChooseHint", 1f);
	}
    void ChooseHint()
    {
        HintLetter = Random.Range(0, RandomWordSelector.ChosenWord.Length);
        Text Output = this.GetComponent<Text>();
        Output.text = ("Letter number " + (HintLetter + 1) + " is: " + RandomWordSelector.ChosenWord[HintLetter]);
    }
}
