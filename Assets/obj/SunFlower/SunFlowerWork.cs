using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerWork : MonoBehaviour
{
    public IsInCamera is_visible;

    public GameObject flower;

    private bool is_sun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(WeatherAdministrator.CurrentWeather == Weather.SUNNY)
        {
            if(!is_sun)
            {
                flower.SetActive(true);
                is_sun = true;
            }
        }
        else
        {
            if (is_sun)
            {
                flower.SetActive(false);
                is_sun = false;
            }
        }
    }
}
