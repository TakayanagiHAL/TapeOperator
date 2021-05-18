using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleWork : MonoBehaviour
{
    [SerializeField] IsInCamera is_visible;
    [SerializeField] float snow_mount = 3.0f / 5.0f;
    [SerializeField] float blizard_mount = 1.0f;
    [SerializeField] Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;
        if (TimeManager.state == TimeManager.TimeState.TIME_PAUSE) return;
        animator.speed = 0;
        is_visible.is_visible = false;

        switch (WeatherAdministrator.CurrentWeather)
        {
            case Weather.SNOW:
                animator.speed = snow_mount;
                break;
            case Weather.BLIZZARD:
                animator.speed = 1;
                break;
        }
    }
}
