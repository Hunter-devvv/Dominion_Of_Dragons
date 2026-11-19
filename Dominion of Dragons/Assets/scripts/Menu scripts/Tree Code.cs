using UnityEngine;

public class TreeCode : MonoBehaviour
{

    public float random_scale_max = 1.2f;
    public float random_scale_min = 0.8f;

    public float y_axis_ajust_multiplier = 1;

    public bool random_x_roation = false;

    public bool random_y_roation = false;
    public bool random_z_roation = true;


    void Start()
    {
        Transform[] difrent_trees = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform tree in difrent_trees)
        {

            print("succses");
            float Multiplier = Random.Range(random_scale_min, random_scale_max);

            tree.localScale *= Multiplier;

            tree.localPosition=new Vector3(tree.localPosition.x , ( (tree.localPosition.y+5+314.19f) * ( ( (Multiplier-1)*y_axis_ajust_multiplier)+1 ) - 5 - 314.19f)  , tree.localPosition.z );


            if (random_x_roation == true)
            {
                tree.localRotation = Quaternion.Euler(Random.Range(0, 360), tree.localRotation.eulerAngles.y, tree.localRotation.eulerAngles.z);
            }
            if (random_y_roation == true)
            {
                tree.localRotation = Quaternion.Euler(0, Random.Range(tree.localRotation.eulerAngles.x, 360), tree.localRotation.eulerAngles.z);
            }
            if (random_z_roation == true)
            {
                tree.localRotation = Quaternion.Euler(tree.localRotation.eulerAngles.x, tree.localRotation.eulerAngles.y, Random.Range(0, 360));
            }
        }

        gameObject.transform.position = new Vector3( 1181.71f, 308.72f, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.localScale = new Vector3(1,1,1);
    }


}
