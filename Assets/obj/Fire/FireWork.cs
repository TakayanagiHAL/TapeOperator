using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    public IsInCamera is_visible;

    public float grow_size = 1.0f/60.0f;

    private int rain_count;

    // Start is called before the first frame update
    void Start()
    {
        rain_count = 3*60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_visible.is_visible) return;

        switch (WeatherAdministrator.CurrentWeather)
        {
            case Weather.RAIN:
                rain_count--;
                break;
            case Weather.STORMY:
                this.transform.localScale.Set(this.transform.localScale.x + grow_size, this.transform.localScale.y, this.transform.localScale.z);
                break;
        }

        if (rain_count <= 0)
        {
            this.enabled = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        BurnObject obj = collision.gameObject.GetComponent<BurnObject>();

        if (obj == null) return;

        obj.Burn();
    }
}
