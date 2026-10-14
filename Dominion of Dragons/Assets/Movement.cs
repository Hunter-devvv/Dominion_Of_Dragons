using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody player;
    public ConstantForce Force;
    public Transform point;
    
    public char mode = 'w';
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = 'w';
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
                
                player.linearVelocity = new Vector3 ((player.position.x-Camera.main.transform.position.x), -0.5f, (player.position.z - Camera.main.transform.position.z)).normalized*5;
                break;

        }
    }
}
