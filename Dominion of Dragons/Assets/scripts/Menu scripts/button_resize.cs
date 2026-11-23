using UnityEngine;
using UnityEngine.InputSystem;

public class button_resize : MonoBehaviour
{
    Vector2 mouse_relitive = new Vector2(0, 0);

    int washovering = 0;
    public AudioSource click;
    public bool IS_hovering_over_play=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IS_hovering_over_play = false;
        mouse_relitive = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //   mouse_x = Input.mousePosition.x - (Screen.width / 2)+960;
        //  mouse_y = Input.mousePosition.y - (Screen.height / 2)+540;

             RectTransform play_button_transform = gameObject.GetComponent<RectTransform>();



    float mouse_x = Input.mousePosition.x;
   float mouse_y = Input.mousePosition.y;

        bool found = RectTransformUtility.ScreenPointToLocalPointInRectangle(play_button_transform, Input.mousePosition, null, out mouse_relitive);

        if (found == true)
        {
          float  h_hight = Mathf.Abs(play_button_transform.sizeDelta.y) / 2;
           float h_width = Mathf.Abs(play_button_transform.sizeDelta.x) / 2;



            int n = (-1);

            if (mouse_relitive.x < h_width && mouse_relitive.x > h_width * n && mouse_relitive.y < h_hight && mouse_relitive.y > h_hight * n)
            {
                IS_hovering_over_play = true;
            
                play_button_transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                if (washovering == 0)
                {
                    click.Play();
                    washovering = 1;
                  
                }
            }
            else
            {
                IS_hovering_over_play = false;
                play_button_transform.localScale = new Vector3(1f, 1f, 1f);

                washovering = 0;
            }
        }

        //these vareables are half of the width and hight.
    }
}
