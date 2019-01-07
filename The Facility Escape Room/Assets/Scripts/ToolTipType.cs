using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipType : MonoBehaviour {


    public static string ToolTipText = " ";
    private string last_ToolTipText = " ";
    private string TooltipText;
    public static bool ToolTipShowing = false;

    public AudioSource TypeAudioSource;
    public AudioClip PaperRaiseSound;
    public AudioClip TypeSound;

    public float Delay = 0.1f;
    public Text OutputText;
    public GameObject Paper;
    

    void Start()
    {
        OutputText.text = "";
    }

    public static void CreateTooltip(string text)
    {
        if(ToolTipShowing == false)
        {
            ToolTipShowing = true;
            ToolTipText = text;
        }
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
            StartCoroutine(RaisePaper());
    }

    public IEnumerator RaisePaper()
    {
        TypeAudioSource.clip = PaperRaiseSound;
        TypeAudioSource.Play();
        for (int i = 0; i< 100; i++ )
        {
            Paper.transform.position = new Vector3(Paper.transform.position.x, Paper.transform.position.y + 1, Paper.transform.position.z);
            yield return new WaitForSeconds(0.0005f);
        }
        StartCoroutine(TypeText());
    }

    public IEnumerator TypeText()
    {
        TypeAudioSource.clip = TypeSound;
        foreach(char letter in TooltipText.ToCharArray())
        {
            OutputText.text += letter;
            float RandomPitch = Random.Range(-0.3f, 0.3f);
            float NewPitch = 1 + RandomPitch;
            
            if (letter == ' ')
            {
                NewPitch = 1 - 0.5f;
            }

            TypeAudioSource.pitch = NewPitch;
            TypeAudioSource.Play();
            yield return new WaitForSeconds(Delay);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(DeleteText());
    }

    public IEnumerator DeleteText()
    {
        int Length = OutputText.text.Length;
        for (int i = 0; i < Length; i++)
        {
            OutputText.text = OutputText.text.Substring(0, OutputText.text.Length - 1);
            yield return new WaitForSeconds(Delay/2);
        }
        ToolTipText = " ";
        last_ToolTipText = " ";
        StartCoroutine(HidePaper());

    }
    public IEnumerator HidePaper()
    {
        for (int i = 0; i < 100; i++)
        {
            Paper.transform.position = new Vector3(Paper.transform.position.x, Paper.transform.position.y - 1, Paper.transform.position.z);
            yield return new WaitForSeconds(0.0005f);
        }
        ToolTipShowing = false;
    }

}
