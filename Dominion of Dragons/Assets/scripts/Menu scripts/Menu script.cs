using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Menuscript : MonoBehaviour
{
    public GameObject Ob_Settings;

    public GameObject Ob_Credits;

    public TMP_Dropdown quality;
    public Toggle full;

    public float mouse_x = 0;
    public float mouse_y = 0;

    public float h_hight = 0;
    public float h_width = 0;

    public Vector2 mouse_relitive = new Vector2(0, 0);

    public AudioSource click;

    void Start()
    {
        Ob_Credits.SetActive(false);
        Ob_Settings.SetActive(false);

    }

    public void Resolution_change()
    {
        QualitySettings.SetQualityLevel(quality.value,true);
    }

    public void fullscreen()
    {

        if (full.isOn==true)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;

        }
    }


    public void Play()
    {

        SceneManager.LoadScene("game");

    }


    public void Exit()
    {
        Application.Quit();
    }

    public void CloseGUI()
    {
        Ob_Credits.SetActive(false);
        Ob_Settings.SetActive(false);
        

    }

    public void Setting()
    {
        Ob_Credits.SetActive(false);
        Ob_Settings.SetActive(true);

    }

    public void Credits()
    {
        Ob_Credits.SetActive(true);
        Ob_Settings.SetActive(false);
    }

}
