using Unity.Mathematics;
using UnityEngine;

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
        player.rotation = new Quaternion(0, 0, 0, 0);
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

                player.useGravity = false;
                Vector2 velocetyXZY = new Vector3((player.position.x - Camera.main.transform.position.x), (player.position.y - Camera.main.transform.position.y), (player.position.z - Camera.main.transform.position.z)).normalized*8;


                if (point.rotation.x > 0)
                {


                    float presentageUP = ( Mathf.Clamp(  ((point.rotation.x)-10),0, 90 ) / 90);

                    TOTALMOMENTUM = Mathf.Clamp(TOTALMOMENTUM + (0.1f * presentageUP), 0.1f, 10);

                    momentumDown = TOTALMOMENTUM * presentageUP;
                    momentumforward = TOTALMOMENTUM*(1 - presentageUP);



                }
                else
                {
                    float presentageUP = (point.rotation.x  / 90 );

                    TOTALMOMENTUM = Mathf.Clamp(TOTALMOMENTUM + (0.1f * presentageUP), 0.1f , 10);

                    momentumDown = TOTALMOMENTUM * presentageUP;
                    momentumforward = TOTALMOMENTUM * (1 - presentageUP);


                }
                 
                

                break;

        }
    }
}
