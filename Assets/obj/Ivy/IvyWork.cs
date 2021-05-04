using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvyWork : MonoBehaviour
{

    public float grow_size = 1.0f/60.0f;

    public float max_glow = 10.0f;

    public float min_size = 1.0f;

    public IsInCamera is_visible;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        switch (WeatherAdministrator.CurrentWeather){
            case Weather.SUNNY:
                this.transform.localScale.Set(this.transform.localScale.x, this.transform.localScale.y + grow_size, this.transform.localScale.z);
                break;
            case Weather.RAIN:
                this.transform.localScale.Set(this.transform.localScale.x, this.transform.localScale.y - grow_size, this.transform.localScale.z);
                break;
            case Weather.STORMY:
                this.transform.localScale.Set(this.transform.localScale.x, this.transform.localScale.y - grow_size, this.transform.localScale.z);
                break;
            case Weather.SNOW:
                this.transform.localScale.Set(this.transform.localScale.x, this.transform.localScale.y - grow_size, this.transform.localScale.z);
                break;
        }

        if (this.transform.localScale.y > max_glow)
        {
            this.transform.localScale.Set(this.transform.localScale.x, max_glow, this.transform.localScale.z);
        }

        if (this.transform.localScale.y < min_size)
        {
            this.transform.localScale.Set(this.transform.localScale.x, min_size, this.transform.localScale.z);
        }
    }
}
