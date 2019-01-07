﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour {

    private int[] Code1 = new int[2];
    private int[] Code2 = new int[2];
    private int[] Code3 = new int[3];
    private int[] Code4 = new int[4];
    private int[] Code5 = new int[4];
    private int[] Code6 = new int[5];
    private int[] Code7 = new int[5];
    private int[] Code8 = new int[6];
    private int[] Code9 = new int[7];
    private int[] Code10 = new int[8];

    private bool SequenceStarted = false;
    private int CodeIndex;

    public MeshRenderer RedIndicator;
    public MeshRenderer GreenIndicator;
    public MeshRenderer YellowIndicator;
    public MeshRenderer BlueIndicator;

    public Material Red;
    public Material Green;
    public Material Yellow;
    public Material Blue;

    public Material Blank;

    public AudioClip Note1;
    public AudioClip Note2;
    public AudioClip Note3;
    public AudioClip Note4;

    public static bool CodePlaying = false;

    // Use this for initialization
    void Start () {
        GenerateCodes();
	}
	
	// Update is called once per frame
	void GenerateCodes () {
		for (int i=0; i < Code1.Length; i++)
        {
            Code1[i] = Random.Range(1, 4);
        }
        //-------
        for (int i = 0; i < Code2.Length; i++)
        {
            Code2[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code3.Length; i++)
        {
            Code3[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code4.Length; i++)
        {
            Code4[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code5.Length; i++)
        {
            Code5[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code6.Length; i++)
        {
            Code6[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code7.Length; i++)
        {
            Code7[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code8.Length; i++)
        {
            Code8[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code9.Length; i++)
        {
            Code9[i] = Random.Range(1, 4);
        }
        //------
        for (int i = 0; i < Code10.Length; i++)
        {
            Code10[i] = Random.Range(1, 4);
        }
        //------
    }


    private void Update()
    {
        if (StartSequencePlaying.PlayerInArea == true && SequenceStarted == false)
        {
            SequenceStarted = true;
            StartCoroutine(PlayCode(Code1));
        }
    }

    IEnumerator PlayCode(int[] Code)
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("Playing Code");
        CodePlaying = true;
        for (int i = 0;i<Code.Length; i++ ) {
            Debug.Log(Code[i]);
            if (Code[i] == 1)
            {
                ChangeMaterial(RedIndicator, Red);
                this.GetComponent<AudioSource>().clip = Note1;
                this.GetComponent<AudioSource>().Play();
            }
            else if (Code[i] == 2)
            {
                ChangeMaterial(GreenIndicator, Green);
                this.GetComponent<AudioSource>().clip = Note2;
                this.GetComponent<AudioSource>().Play();
            }
            else if (Code[i] == 3)
            {
                ChangeMaterial(YellowIndicator, Yellow);
                this.GetComponent<AudioSource>().clip = Note3;
                this.GetComponent<AudioSource>().Play();
            }
            else if (Code[i] == 4)
            {
                ChangeMaterial(BlueIndicator, Blue);
                this.GetComponent<AudioSource>().clip = Note4;
                this.GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(3f);
            ChangeMaterial(RedIndicator, Blank);
            ChangeMaterial(GreenIndicator, Blank);
            ChangeMaterial(YellowIndicator, Blank);
            ChangeMaterial(BlueIndicator, Blank);
            yield return new WaitForSeconds(1f);
        }
        CodePlaying = false;
            
    }

    public void ChangeMaterial(MeshRenderer objectToChange, Material newMaterial)
    {
        var materials = objectToChange.materials;
        materials[6] = newMaterial;
        objectToChange.materials = materials;
    }
}