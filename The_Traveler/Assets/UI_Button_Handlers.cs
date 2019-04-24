using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Button_Handlers : MonoBehaviour
{
    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BeginNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BeginNewGameWithStory()
    {
        SceneManager.LoadScene("Introduction");
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
