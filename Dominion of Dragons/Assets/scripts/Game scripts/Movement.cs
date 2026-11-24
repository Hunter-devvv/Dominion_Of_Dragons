using Unity.Mathematics;
using UnityEngine;
using System.Reflection;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody player;
    public ConstantForce Force;
    public Transform point;

    public float momentumDown;
    public float momentumforward;

    public float TOTALMOMENTUM;

    public GameObject Model;

    public Transform dragon;


    public float stanima = 100;
    public float MAX_stanima = 100;

    public float tilt = 0;
    public float flytime = 0;

    public bool fastfly = false;
    public float fly_l_r_present = 0;

    public float boost = 0;

    public Transform move_l;
    public Transform move_r;

    public char mode = 'w';
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilt = 0;
        mode = 'w';
        momentumDown = 0.5f;
        momentumforward = 0.5f;
        TOTALMOMENTUM = 5;
        fastfly = false;
        boost = 0;

    }

    // Update is called once per frame
    void Update()
    {
        print(point.rotation.eulerAngles.x);

        Vector3 velocetyXZY = new Vector3((player.position.x - Camera.main.transform.position.x), (player.position.y - Camera.main.transform.position.y), (player.position.z - Camera.main.transform.position.z)).normalized * 7;
        Vector3 velocetyLEFT = new Vector3((player.position.x - move_l.position.x), (player.position.y - move_l.position.y), (player.position.z - move_l.position.z)).normalized * 7;
        Vector3 velocetyRIGHT = new Vector3((player.position.x - move_r.position.x), (player.position.y - move_r.position.y), (player.position.z - move_r.position.z)).normalized * 7;

        stanima = Mathf.Clamp(stanima, 0, MAX_stanima);

        player.rotation = quaternion.Euler(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.F))
        {

            switch (mode)
            {
                case 'w':
                    mode = 'f';


                    break;
                case 'f' or 'g':
                    mode = 'w';
                    break;
     

            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {

            switch (mode)
            {
                case 'w':
                  

                    break;
                case 'f':

                    mode = 'g';

                    break;
                case 'g':

                    mode = 'f';

                    break;

            }
        }

        switch (mode)
        {

            case 'w':
                player.useGravity = true;
                Force.enabled = false;
                stanima += Time.deltaTime * 5;
                break;
            case 'f': //what to do on each frame while flying

                //dragon rotation
                dragon.rotation = Quaternion.Euler((point.rotation.eulerAngles.x)-5, point.rotation.eulerAngles.y, tilt);


                player.useGravity = false;
                Force.enabled = false;

                int forward = 0;
                int side = 0;

                if (Input.GetKey(KeyCode.W))   //gets keybinds
                {
                    forward++;

                }
                if (Input.GetKey(KeyCode.A))
                {

                    side--;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    forward--;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    side++;

                }

                //sets presentage up vareable(how far up the camera is faceing)
                float presentageUP2 = 0;

                if (point.rotation.eulerAngles.x > 9 && point.rotation.eulerAngles.x < 90)
                {
                     presentageUP2 = (Mathf.Clamp(((point.localRotation.eulerAngles.x) - 10), 0, 90) / 90);

                }
                else
                {
                    if (point.localRotation.eulerAngles.x > 91)
                    {
                        presentageUP2 = (((point.localRotation.eulerAngles.x) - 190) / 90);

                    }
                    else
                    {
                        presentageUP2 = (((point.localRotation.eulerAngles.x) - 10) / 90);

                    }
                }


                    if (forward != 0 || side != 0)
                {
                    if (forward < 0 )
                    {
                      //fly backwards code

                        if (fastfly ==false)
                        {
                           
                            if (presentageUP2 < 0)
                            {
                                stanima -= (0.5f*Time.deltaTime);

                            }
                            else
                            {
                                stanima -= (0.5f+presentageUP2) * Time.deltaTime;

                            }

                            flytime = Mathf.Clamp(flytime-(Time.deltaTime*4),-2.1f, 2f);
                            

                            player.linearVelocity = new Vector3(velocetyXZY.x * (0.7f + flytime), velocetyXZY.y * (0.7f + flytime), velocetyXZY.z * (0.7f + flytime));


                        }
                        else
                        {
                            stanima -= 2f * Time.deltaTime;

                            if (flytime > 4)
                            {
                                flytime = Mathf.Clamp(flytime - (Time.deltaTime * math.clamp(flytime * 1.2f, 1, 1000)), 0, flytime);
                                player.linearVelocity /= (1 + (Time.deltaTime * 1.2f));
                            }
                            else
                            {
                                flytime = Mathf.Clamp(flytime - (Time.deltaTime * math.clamp(flytime * 3, 1, 1000)), 0, flytime);
                                player.linearVelocity /= (1 + (Time.deltaTime * 3));

                            }

                            if (player.linearVelocity.magnitude == 0)
                            {
                                fastfly = false;
                            }
                        }
                    }
                    else
                    {
                        //-------------------------------------------------------------
                        //flytime rate of change, the faster it changes the faster you speed up
                        //---------------------------------------------------------------
                        if (fastfly == false)
                        {

                            if (flytime < 1)
                            {
                                flytime = Mathf.Clamp(flytime + (Time.deltaTime), 0f, 2f);

                            }
                            else if (flytime < 1.5f)
                            {
                                flytime = Mathf.Clamp(flytime + (Time.deltaTime/2), 0f, 2f);

                            }
                            else
                            {
                                flytime = Mathf.Clamp(flytime + (Time.deltaTime/8), 0f, 2f);

                            }
                            



                            //-------------------------------------------------------------
                            //pressing e puts you in fast fly mode
                            //---------------------------------------------------------------
                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                fastfly = true;
                                boost = 3.5f;
                            }
                        }
                        else
                        {

                            //slowly reduces boost
                            if (boost > 0)
                            {
                                boost = Mathf.Clamp ( boost - (Time.deltaTime*3.5f) , 0, 100);
                            }

                            if (flytime < 2)
                            {
                                flytime = Mathf.Clamp(flytime + (Time.deltaTime/2f), 1.5f, 6f);

                            }
                            else if (flytime < 4)
                            {
                                flytime = Mathf.Clamp(flytime + (Time.deltaTime/3f), 1.5f, 6f);

                            }
                            else
                            {
                                flytime = Mathf.Clamp(flytime + (Time.deltaTime/4), 1.5f, 6f);

                            }
                        }


                        if (presentageUP2 < 0)
                        {
                            stanima -= (0.5f * Time.deltaTime);

                        }
                        else
                        {
                            stanima -= (0.5f + presentageUP2) * Time.deltaTime;

                        }



                        if (side == 0)
                        {
                            
                            fly_l_r_present = Mathf.Clamp(fly_l_r_present*0.9f, -1, 1);
                            tilt = Mathf.Clamp((tilt*0.95f), -60, 60);

                            if (Mathf.Abs(fly_l_r_present) < 0.1f)
                            {
                                fly_l_r_present = 0;
                            }
                            if (Mathf.Abs(tilt) < 0.1f)
                            {
                                tilt = 0;
                            }

                        }

                        if (forward == 1 && side == 0)
                        {
                            //fly forward code 

                            if (fastfly == false)
                            {
                                player.linearVelocity = new Vector3(velocetyXZY.x * (0.7f + flytime), velocetyXZY.y * (0.7f + flytime), velocetyXZY.z * (0.7f + flytime));

                            }
                            else
                            {
                                player.linearVelocity = new Vector3(velocetyXZY.x * (0.7f + flytime + boost), velocetyXZY.y * (0.7f + flytime + boost), velocetyXZY.z * (0.7f + flytime + boost));

                            }



                        }
                        else if (forward == 1 && side != 0)
                        {
                            //fly forward right code
                           
                            if (side==(-1))
                            {
                                fly_l_r_present = Mathf.Clamp(fly_l_r_present + (Time.deltaTime * 1f), -0.8f, 0.8f);
                                tilt = Mathf.Clamp((tilt + (Time.deltaTime*20)), -60, 60);
                            }
                            else
                            {
                                fly_l_r_present = Mathf.Clamp(fly_l_r_present - (Time.deltaTime * 1f), -0.5f, 0.8f);
                                tilt = Mathf.Clamp((tilt - (Time.deltaTime * 20)), -60, 60);

                            }


                            if (fastfly == false)
                            {

                                player.linearVelocity = new Vector3(velocetyXZY.x * (0.7f + flytime), velocetyXZY.y * (0.7f + flytime), velocetyXZY.z * (0.7f + flytime));

                            }
                            else
                            {
                                if (fly_l_r_present > 0)
                                {
                                    player.linearVelocity = new Vector3( (velocetyXZY.x * (0.7f + flytime + boost)) + (velocetyRIGHT.x * (Mathf.Abs(fly_l_r_present))), (velocetyXZY.y * (0.7f + flytime + boost)) + (velocetyRIGHT.y * (Mathf.Abs(fly_l_r_present))), (velocetyXZY.z * (0.7f + flytime + boost)) + (velocetyRIGHT.x * (Mathf.Abs(fly_l_r_present))));

                                }
                                else
                                {
                                    player.linearVelocity = new Vector3((velocetyXZY.x * (0.7f + flytime + boost)) + (velocetyLEFT.x * (Mathf.Abs(fly_l_r_present))), (velocetyLEFT.y * (0.7f + flytime + boost)) + (velocetyLEFT.y * (Mathf.Abs(fly_l_r_present))), (velocetyLEFT.z * (0.7f + flytime + boost)) + (velocetyLEFT.x * (Mathf.Abs(fly_l_r_present))));


                                }
                            }



                        }
                        else if (side == 1 && forward == 0)
                        {
                            //fly right code

                            if (fastfly == true)
                            {
                                if (flytime < 2)
                                {
                                    fastfly = false;
                                }

                                //slows flytime 

                                flytime = Mathf.Clamp(flytime - (Time.deltaTime * Mathf.Clamp((flytime / 4), 1f, 1000)), 0, MAX_stanima);
                                player.linearVelocity /= (1 + (Time.deltaTime));
                            }
                            else
                            {



                                if (fly_l_r_present < -0.1f)
                                {
                                    fly_l_r_present = Mathf.Clamp(fly_l_r_present + (Time.deltaTime * 10), -1, 0);
                                    player.linearVelocity = new Vector3(velocetyLEFT.x * (fly_l_r_present * (-1)), velocetyLEFT.y * (fly_l_r_present * (-1)), velocetyLEFT.z * (fly_l_r_present * (-1)));

                                }
                                else 
                                {
                                    fly_l_r_present = Mathf.Clamp(fly_l_r_present + (Time.deltaTime * 2), 0, 1);
                                    player.linearVelocity = new Vector3(velocetyRIGHT.x * (fly_l_r_present), velocetyRIGHT.y * (fly_l_r_present), velocetyRIGHT.z * (fly_l_r_present));

                                }


                            }

                        }
                        else if (side == -1 && forward == 0)
                        {
                            //fly left code
                            

                            //sets the presentige the player moves left
                          


                            if (fastfly == true)
                            {
                                if (flytime < 2)
                                {
                                    fastfly = false;
                                }

                                //slows flytime 

                                flytime = Mathf.Clamp(flytime - (Time.deltaTime * Mathf.Clamp((flytime / 4), 1f, 1000)), 0, MAX_stanima);
                                player.linearVelocity /= (1 + (Time.deltaTime));
                            }
                            else
                            {
                                if (fly_l_r_present > 0.1f)
                                {
                                    fly_l_r_present = Mathf.Clamp(fly_l_r_present - (Time.deltaTime * 10), 0, 1);
                                    player.linearVelocity = new Vector3(velocetyRIGHT.x * (fly_l_r_present), velocetyRIGHT.y * (fly_l_r_present), velocetyRIGHT.z * (fly_l_r_present));

                                }
                                else
                                {
                                    fly_l_r_present = Mathf.Clamp(fly_l_r_present - (Time.deltaTime * 2), -1, 0);
                                    player.linearVelocity = new Vector3(velocetyLEFT.x * (fly_l_r_present*(-1)), velocetyLEFT.y * (fly_l_r_present * (-1)), velocetyLEFT.z * (fly_l_r_present * (-1)));

                                }









                            }

                        }




                    }



                }
                else
                {
                    if (fastfly == false)
                    {
                        flytime = 0;
                        fastfly = false;
                        player.linearVelocity = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        if (flytime < 2)
                        {
                            fastfly = false;
                        }

                        //slows flytime 
                        flytime = Mathf.Clamp(flytime - (Time.deltaTime * Mathf.Clamp((flytime/4),1f,1000)  ), 0, MAX_stanima);
                        player.linearVelocity /= (1 + (Time.deltaTime));


                    }



                    stanima -= 0.3f * Time.deltaTime;



                }



                break;
            case 'g':
                dragon.rotation = Quaternion.Euler((point.rotation.eulerAngles.x)-5, point.rotation.eulerAngles.y, tilt);



                if (point.rotation.eulerAngles.x > 9 && point.rotation.eulerAngles.x<90)
                {

                    player.useGravity = false;

                    float presentageUP = ( Mathf.Clamp(  ((point.localRotation.eulerAngles.x)-10),0, 90 ) / 90);

                    print("B");

                    print(" step 1 " + (point.localRotation.eulerAngles.x));
                    print(" step 2 " + ((point.localRotation.eulerAngles.x)-5));

                    print(" step 3 " + Mathf.Clamp(((point.localRotation.eulerAngles.x) - 5), 0, 90));

                    TOTALMOMENTUM = Mathf.Clamp(TOTALMOMENTUM + ((Time.deltaTime*0.8f) * Mathf.Abs(presentageUP)), 0.3f, 15);

                    momentumDown = TOTALMOMENTUM * presentageUP;
                    momentumforward = TOTALMOMENTUM*(1 - presentageUP);

                    print("step 4 " + presentageUP);


                    print(" Momentum change " + (0.1f * presentageUP));


                }
                else
                {
                    float presentageUP = 0;
                    if (point.localRotation.eulerAngles.x > 91)
                    {
                         presentageUP = (((point.localRotation.eulerAngles.x) - 190) / 90);

                    }
                    else
                    {
                         presentageUP = (((point.localRotation.eulerAngles.x) - 10) / 90);

                    }



                    print("A");


                    TOTALMOMENTUM = Mathf.Clamp(TOTALMOMENTUM - ((Time.deltaTime*0.8f) * Mathf.Abs(presentageUP)), 0.3f, 15);

                    if (TOTALMOMENTUM <=0.1f)
                    {
                        player.useGravity = true;
                    }
                    else
                    {
                        player.useGravity = false;

                    }
                    momentumDown = TOTALMOMENTUM * presentageUP;
                    momentumforward = math.abs(TOTALMOMENTUM * (1 - presentageUP));


                }

                if (player.useGravity == false)
                {

                    player.linearVelocity = new Vector3(velocetyXZY.x * momentumforward, velocetyXZY.y * (momentumDown), velocetyXZY.z * momentumforward);
                }
                else
                {

                                        player.linearVelocity = new Vector3(velocetyXZY.x * (momentumforward), player.linearVelocity.y, velocetyXZY.z * momentumforward);

                }
                break;


        }
    }
}
