using UnityEngine;

public class grass : MonoBehaviour
{
    public SpriteRenderer png;
    public float disXZ = 0;

    // Update is called once per frame
    void Update()
    {
        bool closeeunguh = true;
        

        float disx =  Mathf.Abs(Camera.main.transform.position.x - gameObject.transform.position.x);
        float disy = Mathf.Abs(Camera.main.transform.position.y - gameObject.transform.position.y);
        float disz = Mathf.Abs(Camera.main.transform.position.z - gameObject.transform.position.z);


        disx = disx * disx;
        disy = disy * disy;
        disz = disz * disz;


        disXZ = Mathf.Sqrt(disx + disz);

        if (disXZ > 120 || disy > 300)
        {
            closeeunguh = false;
            png.enabled = false;

        }
        else if (disXZ > 50 || disy > 100)
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
