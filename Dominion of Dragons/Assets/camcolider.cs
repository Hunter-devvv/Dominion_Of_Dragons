using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class camcolider : MonoBehaviour
{
    
    public int colishions = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public CAMERA cam;
    void Start()
    {

        colishions = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        colishions += 1;
        cam.cam_colllide = true;
        print("colide");

    }

    public void OnTriggerStay(Collider other)
    {
        cam.cam_colllide = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        colishions += 1;
        cam.cam_colllide = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        colishions -= 1;
        if (colishions <= 0)
        {
            cam.cam_colllide = false;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        colishions -= 1;
        if (colishions <= 0)
        {
            cam.cam_colllide = false;

        }

    }
}
