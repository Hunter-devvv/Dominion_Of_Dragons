using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class hotkeychanging : MonoBehaviour
{
    public KeyCode[] hotkey = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E};
    
    public void HotkeyChange1()
    {
        hotkey[0] = Event.current.keyCode;
        Debug.Log("meow:" + hotkey[0]);
    }
    public void HotkeyChange2()
    {
        if (Input.GetKeyDown(hotkey[0]))
        {

        }
    }
    public void HotkeyChange3()
    {

    }
    public void HotkeyChange4()
    {

    }
    public void HotkeyChange5()
    {

    }
}
