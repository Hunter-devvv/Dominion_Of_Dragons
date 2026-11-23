using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class hotkeychanging : MonoBehaviour
{
    public KeyCode[] hotkey = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E};
    public GameObject hotkeymenu;
    public GameObject Ob_Settings2;


    public void HotkeyChange1()
    {
        Waitting();
        Debug.Log("youcanpressnow");
        //hotkey[0] = ;
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

    public void settingenable()
    {
        if (hotkeymenu = null)
            return;
        hotkeymenu.SetActive(true);
        Ob_Settings2.SetActive(!false);
    }
    IEnumerator Waitting()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
