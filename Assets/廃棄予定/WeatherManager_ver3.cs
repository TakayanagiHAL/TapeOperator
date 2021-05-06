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

    //天気管理者オブジェクト格納
    GameObject WeatherAdministratorObject;

    //天気管理者オブジェクトスクリプト格納
    WeatherAdministrator WeatherAdministratorScript;

    ////天候と残り時間表示
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

        ////テキスト表示
        //Text WeatherAndRemainTimeView_Text = WeatherAndRemainTimeView.GetComponent<Text>();
        //WeatherAndRemainTimeView_Text.text = "天候" + WeatherAdministratorScript.GetWeather() + "時間状態" + TimeManager.state;

    }
}
