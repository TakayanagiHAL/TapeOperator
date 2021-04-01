using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenWaterWork : MonoBehaviour
{
    private int freez_count;

    private bool is_freez;

    public GameObject water;

    public GameObject fallen_water;

    Renderer is_visible;

    BackData size_data;

    // Start is called before the first frame update
    void Start()
    {
        freez_count = 300;

        is_freez = false;

        size_data = new BackData();
        size_data.Init();
        is_visible = transform.GetChild(0).GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.isVisible) return;

        if (!is_freez)
        {
            Debug.Log(is_freez);
            if(WeatherAdministrator.CurrentWeather == Weather.SNOW)
            {
                freez_count--;

                Debug.Log(freez_count);
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
        else
        {
            Debug.Log(is_freez);
            Vector3 buff;
            switch (TimeManager.state)
            {
                case TimeManager.TimeState.TIME_BACK:
                    water.transform.position = size_data.DataBack();
                    break;
                case TimeManager.TimeState.TIME_FAST:
                    buff = water.transform.position;
                    size_data.AddData(buff);
                    break;
                case TimeManager.TimeState.TIME_PLAY:
                    buff = water.transform.position;
                    size_data.AddData(buff);
                    break;
                case TimeManager.TimeState.TIME_STOP:
                    break;
            }
        }
    }
}
