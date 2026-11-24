using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float helth_maximum = 100;

    public float helth_current = 0;

    public bool is_alive = true;

    [Header("a stunned creature cant move or attack")]
    public bool stunned = false;

    [Header("0=normal      0.5=half speed, attacks half as oftan     1=unable to move or attack")]
    public float Frozen = 0;



    [Header(" X: dammage taken   Y: interval between dammage (in seconds)  Z: time until next dammage instance")]
    public Vector3 dammage_over_time = new Vector3(0, 0, 0);



    [Header("You can use this to add your own custom condishions. use string \"none\" when under no speshal condishion")]
    public string[] Condishions = new string[5]{ "none", "none","none","none","none"};



    [Header("how much longer each of the custom condishions will last")]
    public float[] Condishions_durations = new float[5] {0,0,0,0,0};


    void Start()
    {
        helth_current = helth_maximum;
        is_alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------
        //this code hanndles health
        //--------------------------
        if (helth_current != 0 && is_alive == false)
        {
            helth_current = 0;
        }
        if (helth_current > helth_maximum)
        {
            helth_current = helth_maximum;
        }
        else if (helth_current < 0)
        {
            helth_current = 0;
            is_alive = false;
        }


        //--------------------------
        //this code hanndles Dammge over time
        //--------------------------
        if (dammage_over_time.x > 0)
        {
            if (dammage_over_time.z <= 0)
            {
                dammage_over_time.z = dammage_over_time.y;

                if (is_alive == true)
                {
                    helth_current -= dammage_over_time.x;
                }

            }
            else
            {
                dammage_over_time.z -= Time.deltaTime;

            }
        }

        //-----------------------------------
        //this code hanndles condishions durations
        //-------------------------------------
        for (int i = 0; i < Condishions.Length; i++)
        {
            if (Condishions[i] != "none")
            {
                Condishions_durations[i] -= Time.deltaTime;
                if (Condishions_durations[i] <= 0)
                {
                    Condishions[i] = "none";
                    Condishions_durations[i] = 0;
                }
            }
        }

    }
}
