using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingRoomControl : MonoBehaviour {

    public GameObject Television1;
    public Text NumberText1;
    public GameObject Television2;
    public Text NumberText2;
    public GameObject Television3;
    public Text NumberText3;
    public GameObject Television4;
    public Text NumberText4;
    public GameObject Door;

    public GameObject[] TestAreas = new GameObject[6];

    private AudioSource Speaker;

    private bool SequenceStarted = false;

    public void Start()
    {
        Speaker = this.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Generated") == 0)
        {
            PlayerPrefs.SetInt("WaitingNumber", 7521);
            PlayerPrefs.SetInt("Generated", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && SequenceStarted == false)
        {
            SequenceStarted = true;
            StartCoroutine(CallNumber());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && SequenceStarted == true)
        {
            SequenceStarted = false;
        }
    }

    public IEnumerator CallNumber()
    {
        for (int i = 0; i < TestAreas.Length; i++)
        {
            TestAreas[i].SetActive(false);
        }
        yield return new WaitForSeconds(6f);

        int CurrentNumber = PlayerPrefs.GetInt("WaitingNumber");
        PlayerPrefs.SetInt("WaitingNumber", CurrentNumber + 1);
        int NewNumber = PlayerPrefs.GetInt("WaitingNumber");

        ToolTipType.CreateTooltip(NewNumber.ToString());


        Debug.Log(NewNumber);

        NumberText1.text = NewNumber.ToString();
        NumberText2.text = NewNumber.ToString();
        NumberText3.text = NewNumber.ToString();
        NumberText4.text = NewNumber.ToString();


        int RandomWait = Random.Range(15, 25);
        yield return new WaitForSeconds(RandomWait);

        Door.GetComponent<Animator>().Play("DoorOpen");
        Door.GetComponent<AudioSource>().Play();

        for (int i = 0; i < 4; i++)
        {
            Television1.SetActive(true);
            Television2.SetActive(true);
            Television3.SetActive(true);
            Television4.SetActive(true);
            Speaker.Play();
            yield return new WaitForSeconds(1.5f);
            Television1.SetActive(false);
            Television2.SetActive(false);
            Television3.SetActive(false);
            Television4.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }

        Television1.SetActive(false);
        Television2.SetActive(false);
        Television3.SetActive(false);
        Television4.SetActive(false);

        for(int i = 0; i < TestAreas.Length; i++)
        {
            TestAreas[i].SetActive(true);
        }
    }
}
