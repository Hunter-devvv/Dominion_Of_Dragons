using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CAMERA : MonoBehaviour
{

    public Movement mmovement;
    public bool cam_colllide = false;
    public bool Previus_cam_collide = false;

    public float desiredCampos;

    public Camera cam;

    public Transform camrotation;
    public Vector3 mousescroll;
    public float mousescroll2;
    public Transform meshurer;

    public Transform FAKECAM;
    public Transform meshurer2;

    public Vector3 oldmousepos;
    public Vector2 scrollweel;
    public float thingy;
    // Start is called before the first frame update
    void Start()
    {
     
        oldmousepos = Input.mousePosition;
        mousescroll = new Vector3(0, 0, 0);
        desiredCampos = cam.transform.localPosition.z;
        cam_colllide = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        mousescroll2 = Input.GetAxis("Mouse ScrollWheel");
        thingy = camrotation.rotation.eulerAngles.x;

        if (oldmousepos != Input.mousePosition)
        {
            mousescroll = Input.mousePosition - oldmousepos;

            if (camrotation.rotation.eulerAngles.x > 70 && (mousescroll.y*  (-0.3f)  ) > 0 && camrotation.rotation.eulerAngles.x < 100)
             {
                print("YESSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
                mousescroll.y = 0;
            }
            if (camrotation.rotation.eulerAngles.x < 285 && (mousescroll.y * -0.3f) < 0 && camrotation.rotation.eulerAngles.x > 100)
            {
                print("YESSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");

                mousescroll.y = 0;
            }
        }
        else
        {
            mousescroll = new Vector3(0, 0, 0);
        }


        if (Input.GetMouseButton(1))
        {



            camrotation.rotation = Quaternion.Euler(camrotation.rotation.eulerAngles.x + (mousescroll.y * -0.3f), camrotation.rotation.eulerAngles.y + (mousescroll.x * 0.3f), 0);
        }
        if (mousescroll2 < 0)
        {
            if (cam.transform.localPosition.z >= -35)
            {
                desiredCampos = desiredCampos + (mousescroll2 * 3);
                FAKECAM.localPosition = new Vector3(0, 0, desiredCampos);

                if (cam_colllide == false)
                {
                    if (Previus_cam_collide == false)
                    {
                        if (desiredCampos == (cam.transform.localPosition.z + (mousescroll2 * 3)))
                        {
                            cam.transform.localPosition = new Vector3(0, 0, desiredCampos);

                        }
                        else
                        {
                            if ((mousescroll2 * 3) > cam.transform.localPosition.z)
                            {
                                cam.transform.localPosition = new Vector3(0, 0, (cam.transform.localPosition.z + cam.transform.localPosition.z+ cam.transform.localPosition.z+ desiredCampos) / 4);

                            }
                            else
                            {
                                desiredCampos = cam.transform.localPosition.z + (mousescroll2 * 3);
                                cam.transform.localPosition = new Vector3(0, 0, desiredCampos);

                            }

                        }

                    }
                    else
                    {

                    }

                }
                else
                {
                    float distancethinguy = Mathf.Abs(cam.transform.localPosition.z);

                    if (distancethinguy > 8)
                    {
                        cam.transform.localPosition = new Vector3(0, 0, cam.transform.localPosition.z + (0.3f));

                    }
                    else if (distancethinguy > 2)
                    {

                        cam.transform.localPosition = new Vector3(0, 0, cam.transform.localPosition.z + (0.1f));
                    }
                    else
                    {
                        cam.transform.localPosition = new Vector3(0, 0, cam.transform.localPosition.z + (0.05f));

                    }



                }


            }

        }
        else
        {
            if (cam.transform.localPosition.z <= -1.8)
            {
                desiredCampos = desiredCampos + (mousescroll2 * 3);
                FAKECAM.localPosition = new Vector3(0, 0, desiredCampos);
                

                if (cam_colllide == false)
                {
                    
                    if (Previus_cam_collide == false)
                    {
                        if (desiredCampos == (cam.transform.localPosition.z + (mousescroll2 * 3)))
                        {
                            cam.transform.localPosition = new Vector3(0, 0, desiredCampos);

                        }
                        else
                        {
                            if ((mousescroll2 * 3) > cam.transform.localPosition.z)
                            {
                                cam.transform.localPosition = new Vector3(0, 0, (cam.transform.localPosition.z+ cam.transform.localPosition.z+ cam.transform.localPosition.z + desiredCampos) / 4);

                            }
                            else
                            {
                                desiredCampos = cam.transform.localPosition.z + (mousescroll2 * 3);
                                cam.transform.localPosition = new Vector3(0, 0, desiredCampos);

                            }

                        }

                    }
                    


                }
                else
                {
                    float distancethinguy = Mathf.Abs(cam.transform.localPosition.z);

                    if (distancethinguy > 8)
                    {
                        cam.transform.localPosition = new Vector3(0, 0, cam.transform.localPosition.z + (0.3f));

                    }
                    else if (distancethinguy > 2)
                    {

                        cam.transform.localPosition = new Vector3(0, 0, cam.transform.localPosition.z + (0.1f));
                    }
                    else
                    {
                        cam.transform.localPosition = new Vector3(0, 0, cam.transform.localPosition.z + (0.05f));

                    }







                }


            }
        }


        oldmousepos = Input.mousePosition;

        meshurer.position = new Vector3((cam.transform.position.x + camrotation.position.x) / 2, (cam.transform.position.y + camrotation.position.y) / 2, (cam.transform.position.z + camrotation.position.z) / 2);
        meshurer.rotation = camrotation.rotation;
        float distanceX = Mathf.Abs(cam.transform.position.x - camrotation.position.x);
        float distanceZ = Mathf.Abs(cam.transform.position.z - camrotation.position.z);
        float distanceY = Mathf.Abs(cam.transform.position.y - camrotation.position.y);


        float distance = MathF.Cbrt( (distanceX*distanceX*distanceX) + (distanceY * distanceY * distanceY) + (distanceZ * distanceZ * distanceZ));

        meshurer.localScale = new Vector3(0.3f, 0.3f, distance);
        BoxCollider camlook_hitbox = meshurer.gameObject.GetComponent<BoxCollider>();


        meshurer2.position = new Vector3((FAKECAM.position.x + camrotation.position.x) / 2, (FAKECAM.position.y + camrotation.position.y) / 2, (FAKECAM.position.z + camrotation.position.z) / 2);
        meshurer2.rotation = camrotation.rotation;
        float distanceX2 = Mathf.Abs(FAKECAM.position.x - camrotation.position.x);
        float distanceZ2 = Mathf.Abs(FAKECAM.position.z - camrotation.position.z);
        float distanceY2 = Mathf.Abs(FAKECAM.position.y - camrotation.position.y);


        float distance2 = MathF.Cbrt((distanceX2 * distanceX2 * distanceX2) + (distanceY2 * distanceY2 * distanceY2) + (distanceZ2 * distanceZ2 * distanceZ2));

        meshurer2.localScale = new Vector3(0.3f, 0.3f, desiredCampos);
        BoxCollider camlook_hitbox2 = meshurer2.gameObject.GetComponent<BoxCollider>();





      
        

    }

   
}