using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�V�C
public enum Weather
{
    SUNNY,
    RAIN,
    STORMY,
    SNOW,
}

public class WeatherAdministrator : MonoBehaviour
{
    //���݂̓V�C
    public static Weather CurrentWeather = Weather.SUNNY;

    //----------�p�[�e�B�N��-------------//
    [SerializeField] ParticleSystem RainParticle;//�J�p�[�e�B�N��
    [SerializeField] ParticleSystem SnowParticle;//��p�[�e�B�N��

    ParticleSystem.EmissionModule RainEmObj;
    ParticleSystem.EmissionModule SnowEmObj;

    // Start is called before the first frame update
    void Start()
    {
        RainEmObj = RainParticle.emission;
        SnowEmObj = SnowParticle.emission;
    }

    // Update is called once per frame
    void Update()
    {
        switch(CurrentWeather)
        {
            case Weather.SUNNY:
                RainEmObj.rateOverTime = 0;
                SnowEmObj.rateOverTime = 0;
                break;
            case Weather.RAIN:;
                RainEmObj.rateOverTime = 100;
                SnowEmObj.rateOverTime = 0;
                break;
            case Weather.STORMY:

                break;
            case Weather.SNOW:
                RainEmObj.rateOverTime = 0;
                SnowEmObj.rateOverTime = 100;
                break;
        }
       // Debug.Log(CurrentWeather);
    }

    //�V�C�Z�b�g
    public void SetWeather(Weather weather)
    {
        CurrentWeather = weather;
    }

    //�V�C�擾
    public Weather GetWeather()
    {
        return CurrentWeather;
    }


}
