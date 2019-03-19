using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] scenes = GameObject.FindGameObjectsWithTag("SceneManager");
        if (objs.Length > 1)
            Destroy(objs[1]);
        if (scenes.Length > 1)
            Destroy(scenes[1]);

        DontDestroyOnLoad(objs[0]);
        //DontDestroyOnLoad(GameObject.FindWithTag("MainCamera"));
    }
}
