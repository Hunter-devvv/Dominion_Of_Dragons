using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform dragon;
    public Animation Anim;

    public AnimationClip Flap;
    float rotation = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation+=Time.deltaTime*5;
        dragon.rotation = Quaternion.Euler(0, rotation, 0);

        
    }
}
