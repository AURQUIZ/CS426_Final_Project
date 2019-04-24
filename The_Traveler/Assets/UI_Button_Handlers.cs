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

    void Start()
    {
        Text start_game_button = GameObject.Find("StartGame").GetComponentInChildren<Text>();//.text = "la di da";
        Text end_game_button = GameObject.Find("EndGame").GetComponentInChildren<Text>();
        if(start_game_button != null)
        {
            start_game_button.text = "Start Game";
            end_game_button.text = "End Game";

        }
    }


    public void BeginNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BeginNewGameWithStory()
    {

    }

    public void ShowControls()
    {

    }

    public void EndGame()
    {

    }
}
