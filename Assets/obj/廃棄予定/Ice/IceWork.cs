using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWork : MonoBehaviour
{
    public float min_size = 1.0f/3.0f;

    public float small_size = (1.0f / 3.0f) / (60.0f * 5.0f);

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

        if(WeatherAdministrator.CurrentWeather == Weather.SUNNY)
        {
            this.transform.localScale.Set(this.transform.localScale.x - small_size, this.transform.localScale.y - small_size, this.transform.localScale.z - small_size);
        }

        if (this.transform.localScale.y < min_size)
        {
            this.transform.localScale.Set(min_size, min_size, min_size);
        }
    }
}
