using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipType : MonoBehaviour {


    public static string ToolTipText = " ";
    private string last_ToolTipText = " ";

    private string TooltipText;
    public AudioSource TypeAudioSource;
    public float Delay = 0.1f;
    public Text OutputText;

    void Start()
    {
        OutputText.text = "";
    }

    private void Update()
    {
        if (ToolTipText == " ")
        {

        }
        else if (last_ToolTipText != ToolTipText)
        {
            Debug.Log("Typing");
            WriteText(ToolTipText);
            last_ToolTipText = ToolTipText;
        }
    }

    public void WriteText(string text)
     {
            TooltipText = text;
            StartCoroutine(TypeText());
    }

    
    public IEnumerator TypeText()
    {
        foreach(char letter in TooltipText.ToCharArray())
        {
            OutputText.text += letter;
            float RandomPitch = Random.Range(-0.3f, 0.3f);
            float NewPitch = 1 + RandomPitch;
            TypeAudioSource.pitch = NewPitch;
            TypeAudioSource.Play();
            yield return new WaitForSeconds(Delay);
        }
        StartCoroutine(FadeAway());
    }

    public IEnumerator FadeAway()
    {
        int Length = OutputText.text.Length;
        for (int i = 0; i < Length; i++)
        {
            OutputText.text = OutputText.text.Substring(0, OutputText.text.Length - 1);
            yield return new WaitForSeconds(Delay/2);
        }
        ToolTipText = " ";
        last_ToolTipText = " ";
        
    }

}
