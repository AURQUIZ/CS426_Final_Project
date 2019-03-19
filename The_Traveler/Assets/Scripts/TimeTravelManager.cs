using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravelManager : MonoBehaviour
{
    private Scene currentScene;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.F))
        //    SingletonDataHolder.setData(SingletonDataHolder.getData() + 1);
        //Debug.Log(SingletonDataHolder.getData());
        currentScene = SceneManager.GetActiveScene();
        if(Input.GetKey(KeyCode.Q))
        {
            SingletonDataHolder.SetPlayerPosition(player.transform.position);
            if(currentScene.name.Equals("Level_01_Good_Timeline"))
                SceneManager.LoadScene("SampleScene");
            else
                SceneManager.LoadScene("Level_01_Good_Timeline");
            //Application.LoadLevel("Level_01_Good_Timeline");
        }
    }

    void OnSceneLoaded()
    {
        player.transform.position = SingletonDataHolder.GetPlayerPosition();
    }
}
