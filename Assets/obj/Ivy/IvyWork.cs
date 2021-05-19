using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvyWork : MonoBehaviour
{

    public float grow_size = 1.0f/60.0f/3.0f;

    //public float max_glow = 10.0f;

    public float min_size = 1.0f;

    public IsInCamera is_visible;

    public GameObject[] mid = new GameObject[8];

    public GameObject top;

    private int current_glow;

    private int mid_couont = 8;

    [SerializeField] 

    // Start is called before the first frame update
    void Start()
    {

        current_glow = 0;

        for(int i = 1; i < mid_couont; i++)
        {
            mid[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        is_visible.is_visible = false;

        if (WeatherAdministrator.CurrentWeather == Weather.SUNNY)
        {
            Debug.Log("glow");

            top.transform.localPosition = new Vector3(top.transform.localPosition.x, top.transform.localPosition.y + grow_size, top.transform.localPosition.z);

            int top_pos = (int)top.transform.localPosition.y;

            for (int i = mid_couont-1; i > top_pos; i--)
            {
                mid[i].transform.localPosition = new Vector3(mid[i].transform.localPosition.x, mid[i].transform.localPosition.y + grow_size, mid[i].transform.localPosition.z);
            }

            if (top.transform.localPosition.y >= 8)
            {
                top.transform.localPosition = new Vector3(top.transform.localPosition.x, 8, top.transform.position.z);
            }
            //mid[current_glow].transform.localScale.Set(mid[current_glow].transform.localScale.x, (mid[current_glow].transform.localScale.y + grow_size), mid[current_glow].transform.localScale.z);

            //for (int i = current_glow; i < mid_couont; i++)
            //{
            //    mid[i].transform.localPosition.Set(mid[current_glow].transform.localPosition.x, mid[current_glow].transform.localPosition.y + grow_size / 2, mid[current_glow].transform.localScale.z);
            //}

            //top.transform.localPosition.Set(top.transform.localPosition.x, top.transform.localPosition.y + grow_size / 2, top.transform.localScale.z);


            //if (mid[current_glow].transform.localScale.y >= 1)
            //{
            //    mid[current_glow].transform.localScale.Set(mid[current_glow].transform.localScale.x, 1.0f, mid[current_glow].transform.localScale.z);

            //    current_glow++;

            //    if (current_glow >= mid_couont)
            //    {
            //        current_glow = 7;
            //    }
            //}
        }
        else
        {

            top.transform.Translate(0, -grow_size, 0);

            int top_pos = (int)top.transform.localPosition.y;

            for (int i = mid_couont-1; i > top_pos; i--)
            {
                mid[i].transform.Translate(0, -grow_size, 0);
            }

            if (top.transform.localPosition.y <= 0)
                {
                    top.transform.localPosition = new Vector3(top.transform.localPosition.x, 0, top.transform.position.z);
                for (int i = mid_couont - 1; i > top_pos; i--)
                {
                    mid[i].transform.localPosition = new Vector3(top.transform.localPosition.x, 0, top.transform.position.z);
                }
            }

                //mid[current_glow].transform.localScale.Set(mid[current_glow].transform.localScale.x, mid[current_glow].transform.localScale.y - grow_size, mid[current_glow].transform.localScale.z);

                //for (int i = mid_couont-1; i >= current_glow; i--)
                //{
                //    mid[i].transform.localPosition.Set(mid[current_glow].transform.localPosition.x, mid[current_glow].transform.localPosition.y - grow_size / 2, mid[current_glow].transform.localPosition.z);
                //}

                //top.transform.localPosition.Set(top.transform.localPosition.x, top.transform.localPosition.y - grow_size / 2, top.transform.localScale.z);


                //if (mid[current_glow].transform.localScale.y <= 0.1)
                //{
                //    mid[current_glow].transform.localScale.Set(mid[current_glow].transform.localScale.x, 0.1f, mid[current_glow].transform.localScale.z);

                //    current_glow--;

                //    if (current_glow <0)
                //    {
                //        current_glow = 0;
                //    }
                //}
            
        }
    }
}
