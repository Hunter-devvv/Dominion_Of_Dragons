using Unity.VisualScripting;
using UnityEngine;

public class randomcamps : MonoBehaviour
{
    public GameObject camp;
    public GameObject Adultobj;
    public float campX = 0.00f;
    public float campZ = 0.00f;
    public float campY = 0.00f;
    public float Randomcampx = 0.00f;
    public float randomcampZ = 0.00f;
    public float randomcampY = 0.00f;
    public float limitXmin = -7.1f;
    public float limitXmax = 450f;
    public float limitymin = -206f;
    public float limitymax = 254f;
    public int camps = 0;
    public int campslimit = 5;
    [Header("area")]
    public float areahight = 2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (camps <= 5)
        {
            randomcampY = Random.Range(limitymin, limitymax);
            Randomcampx = Random.Range(limitXmin, limitXmax);
            Vector3 spawnPos = new Vector3(Randomcampx, areahight, randomcampY);
            var campsspawn = Instantiate(camp, spawnPos, Quaternion.identity);
            campsspawn.transform.transform.parent = Adultobj.transform;
            camps = camps + 1;
        }

    }
}
