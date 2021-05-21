using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeatherSeSound : MonoBehaviour
{
    private SoundManager Sound;

    Weather oldWeather;
    Weather nowWeather;



    bool isChange;  //切替フラグ
    bool isPlay;    //再生中判定

    int frame;  //フレームカウント

    string se_name;

    // Start is called before the first frame update
    void Start()
    {
        //weather = GameObject.Find("WeatherAdministrator").GetComponent<WeatherAdministrator>();
        nowWeather = WeatherAdministrator.CurrentWeather;

        oldWeather = WeatherAdministrator.CurrentWeather + 1;

        Sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        isPlay = false;
        se_name = " ";
        frame = 0;

    }

    // Update is called once per frame
    void Update()
    {
        nowWeather = WeatherAdministrator.CurrentWeather;

        if (nowWeather != oldWeather)
        {

            switch (nowWeather)
            {
                case Weather.SUNNY:
        
                    
                    if(isPlay)
                    {
                        Sound.StopSe(se_name);
                    }

                    isPlay = true;
                    Sound.PlaySeByName("SE_Sunny");
                    se_name = "SE_Sunny";



                    break;
                case Weather.RAIN:

                    if (isPlay)
                    {
                        Sound.StopSe(se_name);
                    }

                    Sound.PlaySeByName("SE_Rain");
                    isPlay = true;

                    se_name = "SE_Rain";
                    break;
                case Weather.STORMY:

                    if (isPlay)
                    {
                        Sound.StopSe(se_name);
                    }

                    Sound.PlaySeByName("SE_Wind");

                    isPlay = true;
                    se_name = "SE_Wind";
                    break;
                case Weather.SNOW:

                    if (isPlay)
                    {
                        Sound.StopSe(se_name);
                    }

                    Sound.PlaySeByName("SE_Snow");
                    isPlay = true;
                    se_name = "SE_Snow";
                    break;

                case Weather.BLIZZARD:

                    if (isPlay)
                    {
                        Sound.StopSe(se_name);
                    }

                    Sound.PlaySeByName("SE_Blizzard");
                    isPlay = true;
                    se_name = "SE_Blizzard";
                    break;
            }

            oldWeather = nowWeather;

        }
        else
        {
            if (isPlay)
            {
                frame++;

                if (frame > 120)
                {

                    switch (nowWeather)
                    {
                        case Weather.SUNNY:

                            Sound.StopSe("SE_Sunny");
                            isPlay = true;
                            break;
                        case Weather.RAIN:

                            Sound.StopSe("SE_Rain");
                            isPlay = true;
                            break;
                        case Weather.STORMY:

                            Sound.StopSe("SE_Wind");

                            isPlay = true;
                            break;
                        case Weather.SNOW:

                            Sound.StopSe("SE_Snow");
                            isPlay = true;
                            break;

                        case Weather.BLIZZARD:

                            Sound.StopSe("SE_Blizzard");
                            isPlay = true;
                            break;
                    }
                    isPlay = false;
                    frame = 0;
                }
            }
        }

    }
}
