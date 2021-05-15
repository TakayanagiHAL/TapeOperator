using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleWork : MonoBehaviour
{
    [SerializeField] IsInCamera is_visible;
    [SerializeField] float snow_mount = 1.0f / 60.0f / 5.0f;
    [SerializeField] float blizard_mount = 1.0f / 60.0f / 3.0f;
    [SerializeField] int sun_flame = 60 * 5;
    [SerializeField] Rigidbody rigidbody;
    private bool is_cold;
    // Start is called before the first frame update
    void Start()
    {
        is_cold = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_cold) return;
        if (!is_visible.is_visible) return;
        if (TimeManager.state == TimeManager.TimeState.TIME_PAUSE) return;

        is_visible.is_visible = false;

        switch (WeatherAdministrator.CurrentWeather)
        {
            case Weather.SUNNY:
                sun_flame--;
                if (sun_flame <= 0)
                {
                    this.enabled = false;
                }
                break;
            case Weather.SNOW:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + snow_mount, transform.localScale.z);
                if (transform.localScale.y >= 1.0f)
                {
                    Debug.Log("Cold");
                    rigidbody.useGravity = true;
                    is_cold = true;
                }
                break;
        }
    }
}
