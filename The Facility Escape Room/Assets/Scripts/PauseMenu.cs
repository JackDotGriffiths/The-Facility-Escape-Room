using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private bool Paused = false;

    public GameObject SpawnPoint;
    public GameObject Player;
    public GameObject PausedMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && Paused == false && EscapeEntranceControl.PlayerCanPause == true)
        {
            LockUnlockPlayer.LockPlayer();
            PausedMenu.SetActive(true);
            Paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Paused == true)
        {
            LockUnlockPlayer.UnlockPlayer();
            PausedMenu.SetActive(false);
            Paused = false;
        }
    }

    public void Restart()
    {
        PausedMenu.SetActive(false);
        LockUnlockPlayer.UnlockPlayer();
        Player.transform.position = SpawnPoint.transform.position;
    }

    public void MainMenu()
    {
        PausedMenu.SetActive(false);
        LockUnlockPlayer.UnlockPlayer();
        SceneManager.LoadScene(0);
    }
}
