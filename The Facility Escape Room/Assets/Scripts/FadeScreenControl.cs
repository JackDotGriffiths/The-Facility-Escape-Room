using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenControl : MonoBehaviour {

    public Image BlackScreen;
    public static bool ToggleBlack;

    private bool CurrentlyBlack = false;

    public static void Toggle()
    {
        ToggleBlack = true;
    }

    private void Update()
    {
        if (ToggleBlack != false)
        {
            Debug.Log("Toggling");
            if (CurrentlyBlack == true)
            {
                Debug.Log("Going Clear");
                ToggleBlack = false;
                CurrentlyBlack = true;
                StartCoroutine(GoToClear());
            }
            else
            {
                Debug.Log("Going Black");
                CurrentlyBlack = true;
                ToggleBlack = false;
                StartCoroutine(GoToBlack());
            }
        }
    }

    IEnumerator GoToClear()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            BlackScreen.color = new Color(0, 0, 0, i);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }
    IEnumerator GoToBlack()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            BlackScreen.color = new Color(0, 0, 0, i);
            yield return null;
        }

    }


}
