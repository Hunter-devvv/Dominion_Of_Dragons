using Unity.Mathematics;
using UnityEngine;
using System.Reflection;

public class Movement : MonoBehaviour
{
    public Rigidbody player;
    public ConstantForce Force;
    public Transform point;

    public float momentumDown;
    public float momentumforward;

    public float TOTALMOMENTUM;
    
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
                break;
            case 'f':
                player.useGravity = false;
                Force.enabled = false;
                break;
            case 'g':

                Vector3 velocetyXZY = new Vector3((player.position.x - Camera.main.transform.position.x), (player.position.y - Camera.main.transform.position.y), (player.position.z - Camera.main.transform.position.z)).normalized*8;


                if (point.rotation.eulerAngles.x > 9 && point.rotation.eulerAngles.x<90)
                {

                    player.useGravity = false;

                    float presentageUP = ( Mathf.Clamp(  ((point.localRotation.eulerAngles.x)-10),0, 90 ) / 90);

                    print("B");

                    print(" step 1 " + (point.localRotation.eulerAngles.x));
                    print(" step 2 " + ((point.localRotation.eulerAngles.x)-5));

                    print(" step 3 " + Mathf.Clamp(((point.localRotation.eulerAngles.x) - 5), 0, 90));

                    TOTALMOMENTUM = Mathf.Clamp(TOTALMOMENTUM + (0.02f * Mathf.Abs(presentageUP)), 0.1f, 100000);

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


                    TOTALMOMENTUM = Mathf.Clamp(TOTALMOMENTUM - (0.02f * Mathf.Abs(presentageUP)), 0.1f, 10);

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
