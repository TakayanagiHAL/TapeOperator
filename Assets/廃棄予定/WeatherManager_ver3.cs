using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager_ver3 : MonoBehaviour
{
    [SerializeField] KeyCode ChangeUpWeather;
    [SerializeField] KeyCode ChangeDownWeather;

    [SerializeField] WeatherScheduleConfig weatherSchedule;

    public WetherUI ui;

    private int WeatherNum = 0;

    Weather[] weather = new Weather[]
    {
         Weather.SUNNY,
         Weather.RAIN,
         Weather.SNOW,
    };

    //�V�C�Ǘ��҃I�u�W�F�N�g�i�[
    GameObject WeatherAdministratorObject;

    //�V�C�Ǘ��҃I�u�W�F�N�g�X�N���v�g�i�[
    WeatherAdministrator WeatherAdministratorScript;

    ////�V��Ǝc�莞�ԕ\��
    //public GameObject WeatherAndRemainTimeView = null;

    // Start is called before the first frame update
    void Start()
    {
        WeatherAdministratorObject = GameObject.Find("WeatherAdministrator");
        WeatherAdministratorScript = WeatherAdministratorObject.GetComponent<WeatherAdministrator>();
        WeatherAdministratorScript.SetWeather(weatherSchedule.weathers[0]);
    }

    // Update is called once per frame
    void Update()
    {
        switch (WeatherNum)
        {
            case 0:
                if (Input.GetKeyDown(ChangeUpWeather) || Input.GetButtonDown("TurnRight"))
                {
                    WeatherNum++;
                   // WeatherAdministratorScript.ui.SetChenge();
                }
                if (Input.GetKeyDown(ChangeDownWeather))
                {
                    WeatherNum = 3;
                }
                break;
            case 1:
                if (Input.GetKeyDown(ChangeUpWeather) || Input.GetButtonDown("TurnRight"))
                {
                    WeatherNum++;
                   // WeatherAdministratorScript.ui.SetChenge();
                }
                if (Input.GetKeyDown(ChangeDownWeather))
                {
                    WeatherNum--;
                }
                break;
            case 2:
                if (Input.GetKeyDown(ChangeUpWeather) || Input.GetButtonDown("TurnRight"))
                {
                    WeatherNum++;
                    //WeatherAdministratorScript.ui.SetChenge();
                }
                if (Input.GetKeyDown(ChangeDownWeather))
                {
                    WeatherNum--;
                }
                break;
            case 3:
                if (Input.GetKeyDown(ChangeUpWeather) || Input.GetButtonDown("TurnRight"))
                {
                    WeatherNum = 0;
                    //WeatherAdministratorScript.ui.SetChenge();
                }
                if (Input.GetKeyDown(ChangeDownWeather))
                {
                    WeatherNum--;
                }
                break;
        }

        WeatherAdministratorScript.SetWeather(weatherSchedule.weathers[WeatherNum]);

        ////�e�L�X�g�\��
        //Text WeatherAndRemainTimeView_Text = WeatherAndRemainTimeView.GetComponent<Text>();
        //WeatherAndRemainTimeView_Text.text = "�V��" + WeatherAdministratorScript.GetWeather() + "���ԏ��" + TimeManager.state;

    }
}
