using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    struct WeatherSchedule
    {
        public float Age;       //時間
        public Weather weather; //天気
    }

    //天気スケジュール
    WeatherSchedule[] weatherschedule = new WeatherSchedule[] {
        new WeatherSchedule { Age = 100.0f, weather = Weather.SNOW },
        new WeatherSchedule { Age = 100.0f, weather = Weather.RAIN },
        new WeatherSchedule { Age = 100.0f, weather = Weather.SUNNY },
    };

    //早送りの倍率
    public float FastFeedRate = 1.5f;

    //天気管理者オブジェクト格納
    GameObject WeatherAdministratorObject;

    //天気管理者オブジェクトスクリプト格納
    WeatherAdministrator WeatherAdministratorScript;

    //現在の時間
    private float CurrentTime;

    //天候管理時間
    //次の天候の時間
    private float WeatherManagerNextTime;

    //前の天候の時間
    private float WeatherManagerPastTime;

    //天候切り替えフラグ
    private bool ChangeoverFlag;

    //現在の天候スケジュールのインデックス
    private int WeatherScheduleIndex;

    //天候と残り時間表示
    public GameObject WeatherAndRemainTimeView = null;

    // Start is called before the first frame update
    void Start()
    {
        //格納
        WeatherAdministratorObject = GameObject.Find("WeatherAdministrator");
        WeatherAdministratorScript = WeatherAdministratorObject.GetComponent<WeatherAdministrator>();

        CurrentTime = 0.0f;
        WeatherScheduleIndex = 0;
        WeatherManagerNextTime = weatherschedule[WeatherScheduleIndex].Age;
        WeatherManagerPastTime = 0;
        ChangeoverFlag = false;
        //天気を変える
        WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);
    }

    // Update is called once per frame
    void Update()
    {

        switch (TimeManager.state)
        {
            case TimeManager.TimeState.TIME_PLAY:
                //カウント
                CurrentTime += Time.deltaTime;
                break;
            case TimeManager.TimeState.TIME_STOP:
                break;
            case TimeManager.TimeState.TIME_BACK:
                //カウント
                CurrentTime -= Time.deltaTime;
                break;
            case TimeManager.TimeState.TIME_FAST:
                //カウント
                CurrentTime += FastFeedRate * Time.deltaTime;
                break;
        }

        //逆再生なら
        if (TimeManager.state == TimeManager.TimeState.TIME_BACK)
        {
            //経過時間が切り替え時間を超えたら
            if (WeatherManagerPastTime > CurrentTime)
            {
                //切り替えフラグオンにする
                ChangeoverFlag = true;
            }
        }
        else
        {
            //経過時間が切り替え時間を超えたら
            if (WeatherManagerNextTime < CurrentTime)
            {
                //切り替えフラグオンにする
                ChangeoverFlag = true;
            }
        }

        //切り替えフラグオンなら
        if(ChangeoverFlag)
        {
            //逆再生なら
            if (TimeManager.state == TimeManager.TimeState.TIME_BACK)
            {
                //インデックスが要素数を超えなければ
                if (WeatherScheduleIndex > 0)
                {
                    //天気スケジュールインデックスをへらす
                    WeatherScheduleIndex--;
                }
                else
                {
                    //超えたら最大ににする
                    WeatherScheduleIndex = weatherschedule.Length - 1;
                }

                //天気を変える
                WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

                //次の切り替わる時間を設定
                WeatherManagerNextTime = WeatherManagerPastTime;
                WeatherManagerPastTime -= weatherschedule[WeatherScheduleIndex].Age;

                //切り替えフラグオフにする
                ChangeoverFlag = false;
            }
            else
            {
                //インデックスが要素数を超えなければ
                if (WeatherScheduleIndex < weatherschedule.Length - 1)
                {
                    //天気スケジュールインデックスを増やす
                    WeatherScheduleIndex++;
                }
                else
                {
                    //超えたら最初に戻す
                    WeatherScheduleIndex = 0;
                }

                //天気を変える
                WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

                //次の切り替わる時間を設定
                WeatherManagerPastTime = WeatherManagerNextTime;
                WeatherManagerNextTime += weatherschedule[WeatherScheduleIndex].Age;

                //切り替えフラグオフにする
                ChangeoverFlag = false;
            }

        }

        
        if (Input.GetButtonDown("Select"))
        {
            Debug.Log("TurnRight");
            WeatherScheduleIndex++;
            WeatherScheduleIndex %= 3;

            //天気を変える
            WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

            //次の切り替わる時間を設定
            WeatherManagerPastTime = WeatherManagerNextTime;
            WeatherManagerNextTime += weatherschedule[WeatherScheduleIndex].Age;

            //切り替えフラグオフにする
            ChangeoverFlag = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("TurnLeft"))
        {
            WeatherScheduleIndex--;

            if (WeatherScheduleIndex < 0) WeatherScheduleIndex = 2;

            //天気を変える
            WeatherAdministratorScript.SetWeather(weatherschedule[WeatherScheduleIndex].weather);

            //次の切り替わる時間を設定
            WeatherManagerPastTime = WeatherManagerNextTime;
            WeatherManagerNextTime += weatherschedule[WeatherScheduleIndex].Age;

            //切り替えフラグオフにする
            ChangeoverFlag = false;
        }

        //テキスト表示
        //Text WeatherAndRemainTimeView_Text = WeatherAndRemainTimeView.GetComponent<Text>();
        //WeatherAndRemainTimeView_Text.text = "天候" + weatherschedule[WeatherScheduleIndex].weather + "_残り時間" + (WeatherManagerNextTime - CurrentTime) + "_" + TimeManager.state;
    }
}
