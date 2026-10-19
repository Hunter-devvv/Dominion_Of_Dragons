using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody player;
    public ConstantForce Force;
    public Transform point;

    public float momentum;

    
    
    public char mode = 'w';
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = 'w';
        momentum = 0;
        
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

                float angle_down = (player.position.y - Camera.main.transform.position.y);


                if ( Mathf.Abs(player.position.y - Camera.main.transform.position.y)>(Mathf.Abs(player.position.z - Camera.main.transform.position.z)) + Mathf.Abs(player.position.x- Camera.main.transform.position.x) ) 
                {
                    player.useGravity = true;

                    print("a");
                    momentum = player.linearVelocity.y;
                    player.linearVelocity = new Vector3( ((player.position.x - Camera.main.transform.position.x)) , player.linearVelocity.y , (player.position.z - Camera.main.transform.position.z)).normalized * Mathf.Clamp((10+((player.linearVelocity.y)*0.7f)),2.2f,1000f);

                }
                else
                {
                    print("b");

                    player.useGravity = false;
                    if (momentum < player.linearVelocity.y)
                    {
                        if (momentum > 0)
                        {
                            momentum = 0;
                        }
                        else
                        {
                            momentum = momentum+((0.8f*(1+(momentum/5)))*Time.deltaTime) ;
                            
                        }
                    }
                    player.linearVelocity = new Vector3((player.position.x - Camera.main.transform.position.x), -0.4f, (player.position.z - Camera.main.transform.position.z)).normalized * (8-(momentum*2));
                }

                break;

        }
    }
}
