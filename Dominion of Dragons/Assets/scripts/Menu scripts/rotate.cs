using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform dragon;
    public Transform DRAGON_local;
    public Animation Anim;

   //distance of camera from dragon.
    public int  Camera_distance = 10;
    public int Camera_Roation_offset = 40;

    public float cam_roation = 0;

    public AnimationClip Flap;
    public float rotation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera CCAMERA = Camera.main;

    
        //roatates the camera around the dragon
        rotation += Time.deltaTime*15;
        if (rotation > 360)
        {
            rotation -= 360;
        }
        float cam_pos_x = Mathf.Cos(rotation*Mathf.Deg2Rad) * Camera_distance;
        float cam_pos_z = Mathf.Sin(rotation * Mathf.Deg2Rad) * Camera_distance;

        CCAMERA.transform.position = new Vector3(dragon.position.x + cam_pos_x, 4.5f, dragon.position.z + cam_pos_z);   //sets the camers position to the dragon, then offsets it by  a number determened by the camera distance and current rotaion angle.


        float distance_x = dragon.position.x - CCAMERA.transform.position.x; 
        float distance_z = dragon.position.z - CCAMERA.transform.position.z;

        if (rotation > 180)
        {
            cam_roation = Mathf.Atan(distance_x / distance_z) * Mathf.Rad2Deg;

        }
        else
        {
            cam_roation = Mathf.Atan(distance_x / distance_z) * Mathf.Rad2Deg+180;

        }

        CCAMERA.transform.rotation = Quaternion.Euler(0 ,  cam_roation+Camera_Roation_offset ,0); //rotates the camera acordingly
        
        
    }
}
