using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObjManager : MonoBehaviour
{

    BackData pos_data;     //位置情報記録用

    public float move_speed = 0.0005f;    //再生時の動くスピード

    public float fast_move = 0.01f;      //早送り時の動くスピード

    public float max_pos_y = 0.8698015f;     //最大位置Y座標（オブジェクトの中心）


    // Start is called before the first frame update
    void Start()
    {
        pos_data = new BackData();
        pos_data.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //雨の時だけ動く
        if (WeatherAdministrator.CurrentWeather == Weather.RAIN)
        {
            Vector3 buff;   //位置の仮保持用


            switch (TimeManager.state)
            {
                case TimeManager.TimeState.TIME_BACK:
                    transform.position = pos_data.DataBack();

                    break;

                case TimeManager.TimeState.TIME_FAST:
                    //位置の仮保持用に移動後の値を入れる
                    buff = new Vector3(transform.position.x, transform.position.y + fast_move, transform.position.z);

                    //最大値異常の場合、最大値にする
                    if (buff.y >= max_pos_y) buff.y = max_pos_y;

                    //ポジションに値を入れる
                    transform.position = buff;

                    //位置情報を保存しておく
                    pos_data.AddData(buff);

                    break;

                case TimeManager.TimeState.TIME_PLAY:
                    //位置の仮保持用に移動後の値を入れる
                    buff = new Vector3(transform.position.x, transform.position.y + move_speed, transform.position.z);

                    //最大値異常の場合、最大値にする
                    if (buff.y >= max_pos_y) buff.y = max_pos_y;

                    //ポジションに値を入れる
                    transform.position = buff;

                    //位置情報を保存しておく
                    pos_data.AddData(buff);

                    break;

                case TimeManager.TimeState.TIME_STOP:
                    break;
            }
        }
    }
}
