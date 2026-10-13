using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class camcolider2 : MonoBehaviour
{

    public int colishions = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public CAMERA cammmmm;
    void Start()
    {

        colishions = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        colishions += 1;
        cammmmm.Previus_cam_collide = true;
        print("colide");

    }

    public void OnTriggerStay(Collider other)
    {
        cammmmm.Previus_cam_collide = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        colishions += 1;
        cammmmm.Previus_cam_collide = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        colishions -= 1;
        if (colishions <= 0)
        {
            cammmmm.Previus_cam_collide = false;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        colishions -= 1;
        if (colishions <= 0)
        {
            cammmmm.Previus_cam_collide = false;

        }

    }
}
