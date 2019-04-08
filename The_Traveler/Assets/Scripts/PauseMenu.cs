using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject playerObject;
    private Movement playerScript;

    void Start()
    {
        playerScript = playerObject.GetComponent<Movement>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resuming game.");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        playerScript.canMove = true;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        playerScript.canMove = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game.");
        Application.Quit();
    }
}
