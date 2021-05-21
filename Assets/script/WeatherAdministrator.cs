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
    BLIZZARD
}

public class WeatherAdministrator : MonoBehaviour
{
    //���݂̓V�C
    public static Weather CurrentWeather = Weather.SUNNY;

    //----------�p�[�e�B�N��-------------//
    [SerializeField] ParticleSystem Rain1Particle;//�J1�p�[�e�B�N��
    [SerializeField] ParticleSystem Rain2Particle;//�J2�p�[�e�B�N��
    [SerializeField] ParticleSystem Snow1Particle;//��1�p�[�e�B�N��
    [SerializeField] ParticleSystem Snow2Particle;//��2�p�[�e�B�N��
    [SerializeField] ParticleSystem WindParticle;//���p�[�e�B�N��
    [SerializeField] ParticleSystem Blizzard1Particle;//����1�p�[�e�B�N��
    [SerializeField] ParticleSystem Blizzard2Particle;//����2�p�[�e�B�N��
    [SerializeField] ParticleSystem Blizzard3Particle;//����3�p�[�e�B�N��
    [SerializeField] ParticleSystem Blizzard4Particle;//����4�p�[�e�B�N��
    [SerializeField] ParticleSystem Blizzard5Particle;//����5�p�[�e�B�N��
    [SerializeField] LightManager lightmanager;//���C�g�Ǘ�      
    [SerializeField] LightConfig lightconfig;//���C�g�X�N���v�^�u���I�u�W�F�N�g

    ParticleSystem.EmissionModule Rain1EmObj;
    ParticleSystem.EmissionModule Rain2EmObj;
    ParticleSystem.EmissionModule Snow1EmObj;
    ParticleSystem.EmissionModule Snow2EmObj;
    ParticleSystem.EmissionModule WindEmObj;
    ParticleSystem.EmissionModule Blizzard1EmObj;
    ParticleSystem.EmissionModule Blizzard2EmObj;
    ParticleSystem.EmissionModule Blizzard3EmObj;
    ParticleSystem.EmissionModule Blizzard4EmObj;
    ParticleSystem.EmissionModule Blizzard5EmObj;

    // Start is called before the first frame update
    void Start()
    {
        Rain1EmObj = Rain1Particle.emission;
        Rain2EmObj = Rain2Particle.emission;
        Snow1EmObj = Snow1Particle.emission;
        Snow2EmObj = Snow2Particle.emission;
        WindEmObj = WindParticle.emission;
        Blizzard1EmObj = Blizzard1Particle.emission;
        Blizzard2EmObj = Blizzard2Particle.emission;
        Blizzard3EmObj = Blizzard3Particle.emission;
        Blizzard4EmObj = Blizzard4Particle.emission;
        Blizzard5EmObj = Blizzard5Particle.emission;
        WindParticle.gameObject.SetActive(false);
        Blizzard1Particle.gameObject.SetActive(false);
    }
    // UBlizzard1EmObj;pdate is called once per frame
    void Update()
    {
        if (TimeManager.state == TimeManager.TimeState.TIME_PAUSE) return;

        switch(CurrentWeather)
        {
            case Weather.SUNNY:
                Rain1EmObj.rateOverTime = 0;
                Rain2EmObj.rateOverTime = 0;
                Snow1EmObj.rateOverTime = 0;
                Snow2EmObj.rateOverTime = 0;
                WindEmObj.rateOverTime = 0;
                Blizzard1EmObj.rateOverTime = 0;
                Blizzard2EmObj.rateOverTime = 0;
                Blizzard3EmObj.rateOverTime = 0;
                Blizzard4EmObj.rateOverTime = 0;
                Blizzard5EmObj.rateOverTime = 0;
                WindParticle.gameObject.SetActive(false);
                Blizzard1Particle.gameObject.SetActive(false);
                lightmanager.SetExPosure(lightconfig.SunNum);
               
                break;
            case Weather.RAIN:
                Rain1EmObj.rateOverTime = 100;
                Rain2EmObj.rateOverTime = 100;
                Snow1EmObj.rateOverTime = 0;
                Snow2EmObj.rateOverTime = 0;
                WindEmObj.rateOverTime = 0;
                Blizzard1EmObj.rateOverTime = 0;
                Blizzard2EmObj.rateOverTime = 0;
                Blizzard3EmObj.rateOverTime = 0;
                Blizzard4EmObj.rateOverTime = 0;
                Blizzard5EmObj.rateOverTime = 0;
                WindParticle.gameObject.SetActive(false);
                Blizzard1Particle.gameObject.SetActive(false);
                lightmanager.SetExPosure(lightconfig.RainNum);
           
                break;
            case Weather.STORMY:
                Rain1EmObj.rateOverTime = 0;
                Rain2EmObj.rateOverTime = 0;
                Snow1EmObj.rateOverTime = 0;
                Snow2EmObj.rateOverTime = 0;
                WindEmObj.rateOverTime = 100;
                Blizzard1EmObj.rateOverTime = 0;
                Blizzard2EmObj.rateOverTime = 0;
                Blizzard3EmObj.rateOverTime = 0;
                Blizzard4EmObj.rateOverTime = 0;
                Blizzard5EmObj.rateOverTime = 0;
                WindParticle.gameObject.SetActive(true);
                Blizzard1Particle.gameObject.SetActive(false);
                lightmanager.SetExPosure(lightconfig.StormyNum);
            
                break;
            case Weather.SNOW:
                Rain1EmObj.rateOverTime = 0;
                Rain2EmObj.rateOverTime = 0;
                Snow1EmObj.rateOverTime = 100;
                Snow2EmObj.rateOverTime = 100;
                WindEmObj.rateOverTime = 0;
                Blizzard1EmObj.rateOverTime = 0;
                Blizzard2EmObj.rateOverTime = 0;
                Blizzard3EmObj.rateOverTime = 0;
                Blizzard4EmObj.rateOverTime = 0;
                Blizzard5EmObj.rateOverTime = 0;
                WindParticle.gameObject.SetActive(false);
                Blizzard1Particle.gameObject.SetActive(false);
                lightmanager.SetExPosure(lightconfig.SnowNum);
              
                break;
            case Weather.BLIZZARD:
                Rain1EmObj.rateOverTime = 0;
                Rain2EmObj.rateOverTime = 0;
                Snow1EmObj.rateOverTime = 0;
                Snow2EmObj.rateOverTime = 0;
                WindEmObj.rateOverTime = 0;
                Blizzard1EmObj.rateOverTime = 100;
                Blizzard2EmObj.rateOverTime = 100;
                Blizzard3EmObj.rateOverTime = 100;
                Blizzard4EmObj.rateOverTime = 100;
                Blizzard5EmObj.rateOverTime = 100;
                WindParticle.gameObject.SetActive(false);
                Blizzard1Particle.gameObject.SetActive(true);
                lightmanager.SetExPosure(lightconfig.BlizzardNum);
               
                break;
            default:
                break;
        }
    }

    //�V�C�Z�b�g
    public void SetWeather(Weather weather)
    {
  
            CurrentWeather = weather;

        switch (CurrentWeather)
        {
            case Weather.SUNNY:
            
                SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Sunny");
                break;
            case Weather.RAIN:
              
                SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Rain");
                break;
            case Weather.STORMY:
               
                SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Wind");
                break;
            case Weather.SNOW:
               
                SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Snow");
                break;
            case Weather.BLIZZARD:
               
                SoundPlayer.GetSoundManagaer().PlaySeByName("SE_Blizzard");
                break;
            default:
                break;
        }

    }

    //�V�C�擾
    public Weather GetWeather()
    {
        return CurrentWeather;
    }


}
