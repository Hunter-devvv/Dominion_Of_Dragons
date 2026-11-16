using UnityEngine;

public class grass : MonoBehaviour
{
    public SpriteRenderer png;
    // Update is called once per frame
    void Update()
    {
        bool closeeunguh = true;
        

        float disx = Mathf.Abs(Camera.main.transform.position.x - gameObject.transform.position.x);
        float disy = Mathf.Abs(Camera.main.transform.position.x - gameObject.transform.position.y);
        float disz = Mathf.Abs(Camera.main.transform.position.x - gameObject.transform.position.z);

        if (disx > 100 || disz > 100 || disy > 200)
        {
            closeeunguh = false;
            png.enabled = false;

        }
        else if (disx > 30 || disz > 30 || disy > 60)
        {
            closeeunguh = false;
            png.enabled = true;


        }
        else
        {
            closeeunguh = true;
            png.enabled = true;

            Camera CCAMERA = Camera.main;
            Transform dragon = gameObject.transform;

            float distance_x = dragon.position.x - CCAMERA.transform.position.x;
            float distance_z = dragon.position.z - CCAMERA.transform.position.z;

           
               float grass_Roatation = Mathf.Atan(distance_x / distance_z) * Mathf.Rad2Deg;

            gameObject.transform.rotation = Quaternion.Euler(0, grass_Roatation,0);
         
        }


    }
}
