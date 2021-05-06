using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{

    public IsInCamera is_visible;

    public Vector3 vector = Vector3.right;

    public float wind_force = 1.0f / (60.0f * 5.0f);

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        vector.Normalize();

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        is_visible.is_visible = false;

        if(WeatherAdministrator.CurrentWeather == Weather.STORMY)
        {
            rigidbody.AddForce((vector * wind_force),ForceMode.Force);
        }
    }
}
