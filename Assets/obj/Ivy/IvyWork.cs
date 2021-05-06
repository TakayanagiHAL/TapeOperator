using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvyWork : MonoBehaviour
{


    public float grow_size = 0.05f;



    public float max_glow = 10.0f;

    public IsInCamera is_visible;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        is_visible.is_visible = false;

        Vector3 buff; 

        if(WeatherAdministrator.CurrentWeather == Weather.SUNNY)
        {
            buff = new Vector3(transform.localScale.x, transform.localScale.y + grow_size, transform.localScale.z);
            if (buff.y >= max_glow) buff.y = max_glow;
            transform.localScale = buff;
        }
        else
        {
            buff = new Vector3(transform.localScale.x, transform.localScale.y - grow_size, transform.localScale.z);
            if (buff.y <= 1) buff.y = 1;
            transform.localScale = buff;
        }

      
    }
}
