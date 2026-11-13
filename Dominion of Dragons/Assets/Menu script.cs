using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    public GameObject Ob_Settings;

    public GameObject Ob_Credits;


    void Start()
    {
        Ob_Credits.SetActive(false);
        Ob_Settings.SetActive(false);

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
