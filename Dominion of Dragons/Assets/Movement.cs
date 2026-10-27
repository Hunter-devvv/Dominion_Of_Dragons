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

    public Animator animator;
    public Animation Anim;

    public AnimationClip Flap;

    public float stanima = 100;
    public float MAX_stanima = 100;

    public float flytime = 0;

    public char mode = 'w';
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        mode = 'w';
        momentumDown = 0.5f;
        momentumforward = 0.5f;
        TOTALMOMENTUM = 5;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocetyXZY = new Vector3((player.position.x - Camera.main.transform.position.x), (player.position.y - Camera.main.transform.position.y), (player.position.z - Camera.main.transform.position.z)).normalized * 7;

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


                player.useGravity = false;
                Force.enabled = false;

                int forward = 0;
                int side = 0;

                if (Input.GetKey(KeyCode.W)) ;  //gets keybinds
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
                        if (flytime < 3)
                        {

                            if (presentageUP2 < 0)
                            {
                                stanima -= (0.5f*Time.deltaTime);

                            }
                            else
                            {
                                stanima -= (0.5f+presentageUP2) * Time.deltaTime;

                            }

                            flytime = 0;
                            player.linearVelocity = new Vector3(velocetyXZY.x*-0.3f , velocetyXZY.y*-0.3f , velocetyXZY.z*-0.3f );


                        }
                        else
                        {
                            stanima -= 2f * Time.deltaTime;

                            flytime = Mathf.Clamp(flytime - (Time.deltaTime * (flytime/2)), 0, MAX_stanima);
                            player.linearVelocity /= (1 + (Time.deltaTime*3));
                       }
                    }
                    else
                    {
                        flytime += Time.deltaTime;
                       
                        if (presentageUP2 < 0)
                        {
                            stanima -= (0.5f * Time.deltaTime);

                        }
                        else
                        {
                            stanima -= (0.5f + presentageUP2) * Time.deltaTime;

                        }

                        if (forward == 1 && side == 0)
                        {
                            if (flytime < 3)
                            {
                                player.linearVelocity = new Vector3(velocetyXZY.x * 0.8f, velocetyXZY.y * 0.8f, velocetyXZY.z * 0.8f);

                            }
                            else
                            {
                                player.linearVelocity = new Vector3(velocetyXZY.x * 2, velocetyXZY.y * 2, velocetyXZY.z * 2);

                            }

                        }
                    }
                    
                    

                }
                else
                {
                    if (flytime < 3)
                    {
                        flytime = 0;
                        player.linearVelocity = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        flytime = Mathf.Clamp(flytime - (Time.deltaTime * (flytime/6)), 0, MAX_stanima);
                        player.linearVelocity /= (1 + (Time.deltaTime));



                    }

                    stanima -= 0.3f * Time.deltaTime;



                }



                break;
            case 'g':



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
