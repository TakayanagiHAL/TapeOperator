using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleWork : MonoBehaviour
{
    [SerializeField] IsInCamera is_visible;
    [SerializeField] float snow_mount = 1.0f / 5.0f/60.0f;
    [SerializeField] float blizard_mount = 1.0f/3.0f/60.0f;
    [SerializeField] Transform icicle;
    [SerializeField] GameObject obj;
    private float flame =0;
    
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
            case Weather.SNOW:
                flame += snow_mount;
                icicle.localScale = new Vector3(icicle.localScale.x, icicle.localScale.y + snow_mount, icicle.localScale.z);
                break;
            case Weather.BLIZZARD:
                flame += blizard_mount;
                icicle.localScale = new Vector3(icicle.localScale.x, icicle.localScale.y + blizard_mount, icicle.localScale.z);
                break;
        }
        if (flame >= 1.0f)
        {
            Instantiate(obj, transform.position, transform.rotation);
            flame = 0.0f;
            icicle.localScale = new Vector3(icicle.localScale.x, 0.0f, icicle.localScale.z);
        }
    }
}
