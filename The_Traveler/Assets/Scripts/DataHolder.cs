using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder 
{
    private static int data = 0;
    private static Vector3 objecPos;

    public static void setData(int d)
    {
        data = d;
    }

    public static int getData()
    {
        return data;
    }

    public static void SetPlayerPosition(Vector3 obj)
    {
        objecPos = obj;
    }
    public static Vector3 GetPlayerPosition()
    {
        return objecPos;
    }

}
