using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherUISe : MonoBehaviour
{
    private SoundManager Sound;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        //Sound.PlaySeByName("SE_WeatherUI");
    }

    // Update is called once per frame
    void Update()
    {

        bool rt = Input.GetButton("FastForward");
        bool lt = Input.GetButton("Rewind");
        if (Input.GetKey(KeyCode.RightArrow) || (rt && !lt))
        {
            Sound.PlaySeByName("SE_WeatherUI");
        }
        if (Input.GetKey(KeyCode.LeftArrow) || (!rt && lt))
        {
            Sound.PlaySeByName("SE_WeatherUI");
        }

        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Sound.StopSe();
        //}
        //if (Input.GetKeyDown(KeyCode.F12))
        //{
        //    Sound.PlaySeByName("SE_WeatherUI");
        //}
    }
}
