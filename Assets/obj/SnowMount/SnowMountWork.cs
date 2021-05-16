using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMountWork : MonoBehaviour
{
    [SerializeField] float snow_mount = 0.1f / 60.0f / 5.0f;
    [SerializeField] float blizard_mount = 0.1f / 60.0f / 3.0f;
    [SerializeField] float max_size = 1;
    [SerializeField] float min_size = 0.1f;
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

        switch (WeatherAdministrator.CurrentWeather)
        {
            case Weather.SUNNY:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - snow_mount, transform.localScale.z);

                if (transform.localScale.y <= min_size)
                {
                    transform.localScale = new Vector3(transform.localScale.x, min_size, transform.localScale.z);
                }
                break;
            case Weather.SNOW:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + snow_mount, transform.localScale.z);
                if (transform.localScale.y >= max_size)
                {
                    transform.localScale = new Vector3(transform.localScale.x, max_size, transform.localScale.z);
                }
                break;
            case Weather.BLIZZARD:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + blizard_mount, transform.localScale.z);
                if (transform.localScale.y >= max_size)
                {
                    transform.localScale = new Vector3(transform.localScale.x, max_size, transform.localScale.z);
                }
                break;
        }
    }
}
