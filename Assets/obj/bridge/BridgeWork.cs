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
        broken = 0;

        for(int i = 0; i < 6; i++)
        {
            rigidbodies[i].useGravity = false;
            rigidbodies[i].constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(is_visible.is_visible);
        if (is_visible.is_visible == false) return;
        is_visible.is_visible = false;
         
       // Debug.Log("look");
        if (broken > 5) return;

       if(WeatherAdministrator.CurrentWeather == Weather.STORMY)
        {
            frame++;
            if(frame%60 == 0)
            {

                Debug.Log("broken");
                Debug.Log(broken);
                rigidbodies[broken].useGravity = true;
                rigidbodies[broken].constraints = RigidbodyConstraints.None;

                broken++;

               
            }
        }

    }
   

}
