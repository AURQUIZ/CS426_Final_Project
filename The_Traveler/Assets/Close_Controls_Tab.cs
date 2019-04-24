using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Controls_Tab : MonoBehaviour
{
    public UI_Button_Handlers uiHandler;

    public void back()
    {
        uiHandler.BackToPause();
    }
}
