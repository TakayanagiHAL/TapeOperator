using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenWaterWork : MonoBehaviour
{
    private int freez_count;

    private bool is_freez;

    public GameObject water;

    public GameObject fallen_water;

    public IsInCamera is_visible;

    // Start is called before the first frame update
    void Start()
    {
        freez_count = 300;

        is_freez = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        if (!is_freez)
        {
            if(WeatherAdministrator.CurrentWeather == Weather.SNOW)
            {
                freez_count--;
            }

            if (freez_count < 0)
            {
                is_freez = true;

                BoxCollider collider = water.GetComponent<BoxCollider>();
                collider.isTrigger = false;

                Rigidbody rigidbody = water.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;
                rigidbody = fallen_water.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;

            }

        }
      
    }
}
