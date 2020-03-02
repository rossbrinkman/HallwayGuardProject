using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxisRaw("J_MainHorizontal");
        r += Input.GetAxisRaw("Horizontal");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxisRaw("J_MainVertical");
        r += Input.GetAxisRaw("Vertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    public static bool AButton()
    {
        return Input.GetButtonDown("AButton");
    }
    public static bool BButton()
    {
        return Input.GetButtonDown("BButton");
    }
    public static bool XButton()
    {
        return Input.GetButtonDown("XButton");
    }
    public static bool YButton()
    {
        return Input.GetButtonDown("YButton");
    }
}
