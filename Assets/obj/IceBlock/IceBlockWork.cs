using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockWork : MonoBehaviour
{
    [SerializeField] float melt_speed = 1.0f / 60.0f/5.0f;
    [SerializeField] IsInCamera is_visible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;
        if (TimeManager.state == TimeManager.TimeState.TIME_PAUSE) return;

        is_visible.is_visible = false;

        if(WeatherAdministrator.CurrentWeather == Weather.SUNNY)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - melt_speed, transform.localScale.z);

            if(transform.localScale.y <= 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
            }
        }
    }
}
