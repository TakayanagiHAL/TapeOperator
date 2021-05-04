using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BridgeWork : MonoBehaviour
{
    public Rigidbody[] rigidbodies = new Rigidbody[6];

    public IsInCamera is_visible;

    private int frame;

    private int broken;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
        broken = -1;

        for(int i = 0; i < 5; i++)
        {
            rigidbodies[i].useGravity = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

       if(WeatherAdministrator.CurrentWeather == Weather.STORMY)
        {
            frame++;
            if(frame%60 == 0)
            {
                broken++;
                rigidbodies[broken].useGravity = true;
            }
        }

    }
   

}
