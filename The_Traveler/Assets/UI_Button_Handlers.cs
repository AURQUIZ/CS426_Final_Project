using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Button_Handlers : MonoBehaviour
{
    public GameObject controlsText;
    //public GameObject backButton;

    public GameObject header;
    public GameObject resume;
    public GameObject controls;
    public GameObject quit;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        header = GameObject.Find("Header");
        resume = GameObject.Find("Resume");
        controls = GameObject.Find("Controls");
        quit = GameObject.Find("Quit");
    }

    public void BeginNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BeginNewGameWithStory()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("End_Game_Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowControlScheme()
    {

        header.SetActive(false);
        resume.SetActive(false);
        controls.SetActive(false);
        quit.SetActive(false);

        controlsText.SetActive(true);
        //backButton.SetActive(true);
    }

    public void BackToPause()
    {

        header.SetActive(true);
        resume.SetActive(true);
        controls.SetActive(true);
        quit.SetActive(true);

        controlsText.SetActive(false);
        //backButton.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void ShowControls()
    {

    }

    public void EndGame()
    {

    }
}
