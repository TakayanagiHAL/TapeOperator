using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockWork : MonoBehaviour
{
    [SerializeField] float melt_speed = 1.0f / 60.0f/5.0f;
    [SerializeField] IsInCamera is_visible;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 0;

        if (!is_visible.is_visible) return;
        if (TimeManager.state == TimeManager.TimeState.TIME_PAUSE) return;

        is_visible.is_visible = false;

        if(WeatherAdministrator.CurrentWeather == Weather.SUNNY)
        {
            Debug.Log("melt");
            animator.speed = 1;
           
        }
    }
}
